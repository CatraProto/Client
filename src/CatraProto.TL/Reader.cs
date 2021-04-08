using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL
{
    public class Reader : IDisposable
    {
        private BinaryReader _reader;
        private IObjectProvider _provider;
        public Stream Stream => _reader.BaseStream;

        public Reader(IObjectProvider provider, Stream stream, bool leaveOpen = false) : this(provider, stream, Encoding.UTF8, leaveOpen)
        {
        }

        public Reader(IObjectProvider provider, Stream stream, Encoding encoding, bool leaveOpen = false)
        {
            _provider = provider;
            _reader = new BinaryReader(stream, encoding, leaveOpen);
        }

        public T Read<T>(int? bitSize = null)
        {
            var typeOfT = typeof(T);
            if (typeOfT == typeof(int))
            {
                return (T)(object)_reader.ReadInt32();
            }
            else if (typeOfT == typeof(string))
            {
                return (T)(object)Encoding.UTF8.GetString(ReadBytes());
            }
            else if (typeOfT == typeof(double))
            {
                return (T)(object)_reader.ReadDouble();
            }
            else if (typeOfT == typeof(long))
            {
                return (T)(object)_reader.ReadInt64();
            }
            else if (typeOfT == typeof(byte))
            {
                return (T)(object)_reader.ReadByte();
            }
            else if (typeOfT == typeof(byte[]))
            {
                return (T)(object)ReadBytes();
            }
            else if (typeOfT == typeof(bool))
            {
                return (T)(object)ReadBool();
            }
            else if (typeOfT == typeof(System.Numerics.BigInteger))
            {
                if (bitSize == null)
                {
                    throw new DeserializationException("Missing parameter bitSize",
                        DeserializationException.DeserializationErrors.MissingParameter);
                }
            }
            else if (typeOfT.GetInterfaces()[^1] == typeof(IObject))
            {
                var id = _reader.ReadInt32();
                var instance = _provider.ResolveConstructorId(id);
                if (instance == null)
                {
                    throw new DeserializationException($"The current provider can't provide an instance for {id}",
                        DeserializationException.DeserializationErrors.ProviderReturnedNull);
                }

                instance.Deserialize(this);
                return (T)instance;
            }

            throw new DeserializationException($"The type {typeOfT} is not supported",
                DeserializationException.DeserializationErrors.TypeNotFound);
        }

        private bool ReadBool()
        {
            var value = Read<IObject>().GetType();
            var boolTrue = _provider.BoolTrue;

            if (boolTrue is null)
            {
                throw new DeserializationException("The provided boolTrue type is null",
                    DeserializationException.DeserializationErrors.BoolTrueNull);
            }

            return _provider.BoolTrue == value;
        }

        private byte[] ReadBytes()
        {
            int lenght = _reader.ReadByte();
            var totalLenght = lenght;
            byte[] data;
            if (lenght <= 253)
            {
                data = _reader.ReadBytes(lenght);
                totalLenght++;
            }
            else
            {
                lenght = _reader.ReadByte() | _reader.ReadByte() << 8 | _reader.ReadByte() << 16;
                totalLenght = lenght + 4;
                data = _reader.ReadBytes(lenght);
            }

            var i = 0;
            while ((totalLenght + i) % 4 != 0)
            {
                i++;
                _reader.ReadByte();
            }

            return data;
        }

        public IList<T> ReadVector<T>(Func<T> action)
        {
            _reader.ReadInt32(); //Going past the vector's id
            var list = new List<T>();
            var size = _reader.ReadInt32();
            for (var i = 0; i < size; i++)
            {
                var deserialized = action();
                list.Add(deserialized);
            }

            return list;
        }

        public IList<T> ReadVector<T>()
        {
            return ReadVector(() => Read<T>());
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}
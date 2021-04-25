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
            return (T)Read(typeof(T), bitSize);
        }

        public object Read(Type type, int? bitSize = null)
        {
            if (type == typeof(int))
            {
                return _reader.ReadInt32();
            }
            else if (type == typeof(string))
            {
                return Encoding.UTF8.GetString(ReadBytes());
            }
            else if (type == typeof(double))
            {
                return _reader.ReadDouble();
            }
            else if (type == typeof(long))
            {
                return _reader.ReadInt64();
            }
            else if (type == typeof(byte))
            {
                return _reader.ReadByte();
            }
            else if (type == typeof(byte[]))
            {
                return ReadBytes();
            }
            else if (type == typeof(bool))
            {
                return ReadBool();
            }
            else if (type == typeof(System.Numerics.BigInteger))
            {
                if (bitSize == null)
                {
                    throw new DeserializationException("Missing parameter bitSize",
                        DeserializationException.DeserializationErrors.MissingParameter);
                }
            }
            else if (type.GetInterfaces()[^1] == typeof(IObject))
            {
                var id = _reader.ReadInt32();
                var instance = _provider.ResolveConstructorId(id);
                if (instance == null)
                {
                    throw new DeserializationException($"The current provider can't provide an instance for {id}",
                        DeserializationException.DeserializationErrors.ProviderReturnedNull);
                }

                instance.Deserialize(this);
                return instance;
            }

            throw new DeserializationException($"The type {type} is not supported",
                DeserializationException.DeserializationErrors.TypeNotFound);
        }

        public Type GetNextType()
        {
            var id = _reader.ReadInt32();
            if (id == _provider.VectorId)
            {
                return typeof(IList<>);
            }

            var instance = _provider.ResolveConstructorId(id);
            return instance?.GetType();
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
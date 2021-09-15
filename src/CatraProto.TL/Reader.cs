using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using CatraProto.TL.ObjectDeserializers;
using CatraProto.TL.Options;

namespace CatraProto.TL
{
    public class Reader : IDisposable
    {
        public Stream Stream
        {
            get => _reader.BaseStream;
        }

        private ICustomObjectDeserializer? _rpcDeserializer;
        private readonly ObjectProvider _provider;
        private readonly BinaryReader _reader;

        public Reader(ObjectProvider provider, Stream stream, bool leaveOpen = false)
        {
            _provider = provider;
            _reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen);
        }

        public void SetRpcDeserializer(ICustomObjectDeserializer customObjectDeserializer)
        {
            _rpcDeserializer = customObjectDeserializer;
        }


        public T Read<T>(int? bitSize = null, DeserializationOptions? deserializationOptions = null)
        {
            return (T)Read(typeof(T), bitSize);
        }

        public object Read(Type type, int? bitSize = null, DeserializationOptions? deserializationOptions = null)
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
                    throw new DeserializationException("Missing parameter bitSize", DeserializationException.DeserializationErrors.MissingParameter);
                }

                return BigInteger.ReadBytes(bitSize.Value, this);
            }
            else if (type == typeof(IObject) || type.GetInterfaces()[^1] == typeof(IObject))
            {
                var id = _reader.ReadInt32();
                var instance = _provider.ResolveConstructorId(id);
                if (instance == null)
                {
                    throw new DeserializationException($"The provider couldn't provide an instance for {id}", DeserializationException.DeserializationErrors.ProviderReturnedNull);
                }

                if (id == _provider.GzipPackedId)
                {
                    var gzipInstance = _provider.ResolveConstructorId(id);
                    gzipInstance!.Deserialize(this);
                    var gzippedBytes = _provider.GetGzippedBytes(gzipInstance);
                    instance = GzipHandler.DeserializeGzippedObject(gzippedBytes, _provider);
                } 
                else if (_rpcDeserializer != null && id == _provider.RpcResultId)
                {
                    _rpcDeserializer.DeserializeObject(instance, this);
                    return instance;
                }
                else
                {
                    instance.Deserialize(this);
                }

                return instance;
            }

            throw new DeserializationException($"The type {type} is not supported", DeserializationException.DeserializationErrors.TypeNotFound);
        }

        public Type? GetNextType()
        {
            var id = _reader.ReadInt32();
            _reader.BaseStream.Position -= 4;
            if (id == _provider.VectorId)
            {
                return typeof(IList<>);
            }

            var instance = _provider.ResolveConstructorId(id);
            return instance?.GetType();
        }

        private bool ReadBool()
        {
            var value = _reader.ReadInt32();
            return value == _provider.BoolTrueId;
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

        public IList<object> ReadVector(Type type, bool naked = false)
        {
            return ReadVector(new RegularObjectVectorDeserializer<object>(type), naked);
        }

        public IList<T> ReadVector<T>(bool naked = false)
        {
            return ReadVector(new RegularObjectVectorDeserializer<T>(typeof(T)), naked);
        }

        public IList<T> ReadVector<T>(ICustomVectorDeserializer<T> vectorDeserializer, bool naked = false)
        {
            if (!naked)
            {
                _reader.BaseStream.Seek(4, SeekOrigin.Current);
            }

            var size = _reader.ReadInt32();

            var list = new List<T>();
            for (var i = 0; i < size; i++)
            {
                list.Add(vectorDeserializer.GetValue(this));
            }

            return list;
        }

        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
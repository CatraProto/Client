using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CatraProto.TL.Exceptions;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL
{
    public class Writer : IDisposable
    {
        public Stream Stream
        {
            get
            {
                _writer.Flush();
                return _writer.BaseStream;
            }
        }

        private readonly ObjectProvider? _provider;
        private readonly BinaryWriter _writer;

        public Writer(ObjectProvider? provider, Stream stream, bool leaveOpen = false) : this(provider, stream, Encoding.UTF8, leaveOpen)
        {
        }

        public Writer(ObjectProvider? provider, Stream stream, Encoding encoding, bool leaveOpen = false)
        {
            _provider = provider;
            _writer = new BinaryWriter(stream, encoding, leaveOpen);
        }

        public void Write<T>(T value)
        {
            if (value == null)
            {
                throw new SerializationException($"{nameof(value)} is null", SerializationException.SerializationErrors.ValueNull);
            }

            switch (value)
            {
                case int i:
                    _writer.Write(i);
                    break;
                case long l:
                    _writer.Write(l);
                    break;
                case string s:
                    Write(Encoding.UTF8.GetBytes(s));
                    break;
                case double d:
                    _writer.Write(d);
                    break;
                case byte b:
                    _writer.Write(b);
                    break;
                case byte[] bb:
                    WriteBytes(bb);
                    break;
                case bool b:
                    WriteBool(b);
                    break;
                case System.Numerics.BigInteger bigInteger:
                    _writer.Write(bigInteger.ToByteArray().RemoveTrailingZeros());
                    break;
                case IObject obj:
                    obj.Serialize(this);
                    break;
                default:
                    throw new SerializationException($"The type {typeof(T)} is not supported", SerializationException.SerializationErrors.TypeNotFound);
            }
        }

        private void WriteBool(bool value)
        {
            ThrowIfProviderNull();
            _writer.Write(value ? _provider!.BoolTrueId : _provider!.BoolFalseId);
        }


        private void WriteBytes(byte[] bytes)
        {
            var arrayLength = bytes.Length;
            var totalLenght = arrayLength;
            if (arrayLength <= 253)
            {
                _writer.Write((byte)arrayLength);
                totalLenght++;

                _writer.Write(bytes);
            }
            else
            {
                _writer.Write((byte)254);
                _writer.Write((byte)arrayLength);
                _writer.Write((byte)(arrayLength >> 8));
                _writer.Write((byte)(arrayLength >> 16));
                totalLenght += 4;

                _writer.Write(bytes);
            }

            var i = 0;
            while ((totalLenght + i) % 4 != 0)
            {
                i++;
                _writer.Write((byte)0);
            }
        }

        public void Write<T>(IList<T> list)
        {
            ThrowIfProviderNull();
            Write(_provider!.VectorId);

            WriteNakedVector(list);
        }

        public void WriteNakedVector<T>(IList<T> list)
        {
            Write(list.Count);
            foreach (var element in list)
            {
                Write(element);
            }
        }

        private void ThrowIfProviderNull()
        {
            if (_provider is null)
            {
                throw new NullReferenceException("Provide an object provider in the constructor");
            }
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}
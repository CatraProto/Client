/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    public class Reader : IDisposable
    {
        public Stream Stream
        {
            get => _reader.BaseStream;
        }

        private readonly UTF8Encoding _utf8Encoder = new UTF8Encoding(false, true);
        private readonly List<IObjectParser> _customParsers;
        private readonly ObjectProvider? _provider;
        private readonly BinaryReader _reader;

        public Reader(ObjectProvider? provider, Stream stream, bool leaveOpen = false, List<IObjectParser>? objectParsers = null)
        {
            _provider = provider;
            _reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen);
            _customParsers = objectParsers ?? new List<IObjectParser>(0);
        }

        public ReadResult<short> ReadInt16()
        {
            var checkLength = CheckLength<short>(sizeof(short));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<short>(_reader.ReadInt16());
        }

        public ReadResult<ushort> ReadUInt16()
        {
            var checkLength = CheckLength<ushort>(sizeof(ushort));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<ushort>(_reader.ReadUInt16());
        }

        public ReadResult<int> ReadInt32()
        {
            var checkLength = CheckLength<int>(sizeof(int));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<int>(_reader.ReadInt32());
        }

        public ReadResult<long> ReadInt64()
        {
            var checkLength = CheckLength<long>(sizeof(long));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<long>(_reader.ReadInt64());
        }

        public ReadResult<double> ReadDouble()
        {
            var checkLength = CheckLength<double>(sizeof(double));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<double>(_reader.ReadDouble());
        }

        public ReadResult<bool> ReadBool()
        {
            var checkProvider = CheckProviderNull<bool>();
            if (checkProvider.IsError)
            {
                return checkProvider;
            }

            var checkLength = CheckLength<bool>(sizeof(int));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            var constructorId = _reader.ReadInt32();
            if (constructorId == _provider!.BoolTrueId)
            {
                return new ReadResult<bool>(true);
            }
            else if (constructorId == _provider.BoolFalseId)
            {
                return new ReadResult<bool>(false);
            }
            else
            {
                return new ReadResult<bool>($"{constructorId} is not boolTrue nor boolFalse", Results.ParserErrors.BoolInvalid);
            }
        }

        public ReadResult<byte> ReadByte()
        {
            var checkLength = CheckLength<byte>(sizeof(byte));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            return new ReadResult<byte>(_reader.ReadByte());
        }

        public ReadResult<byte[]> ReadBytes()
        {
            try
            {
                int lenght = _reader.ReadByte();
                var totalLenght = lenght;
                byte[] data;
                if (lenght <= 253)
                {
                    totalLenght++;
                }
                else
                {
                    lenght = _reader.ReadByte() | _reader.ReadByte() << 8 | _reader.ReadByte() << 16;
                    totalLenght = lenght + 4;
                }

                if (lenght < 0)
                {
                    return new ReadResult<byte[]>("Byte array length is less than 0", ParserErrors.InvalidArrayLength);
                }

                var i = 0;
                data = _reader.ReadBytes(lenght);
                while ((totalLenght + i) % 4 != 0)
                {
                    _reader.ReadByte();
                    i++;
                }

                return new ReadResult<byte[]>(data);
            }
            catch (ArgumentException)
            {
                //While this might look bad, it's worse to add a lot of boilerplate for something that could happen very rarely.
                return new ReadResult<byte[]>("Could not read byte array because stream is not long enough", Results.ParserErrors.StreamTooShort);
            }
        }

        public ReadResult<string> ReadString()
        {
            var readBytes = ReadBytes();
            if (readBytes.IsError)
            {
                return ReadResult<string>.Move(readBytes);
            }

            try
            {
                return new ReadResult<string>(_utf8Encoder.GetString(readBytes.Value));
            }
            catch (ArgumentException)
            {
                return new ReadResult<string>("The byte-array contains an invalid sequence of bytes", ParserErrors.UTF8InvalidSequence);
            }
        }

        public ReadResult<BigInteger> ReadBigInteger(int bitSize)
        {
            var byteCount = bitSize / 8;
            var bytes = new byte[byteCount];
            var checkLength = CheckLength<BigInteger>(byteCount);
            if (checkLength.IsError)
            {
                return checkLength;
            }

            _reader.BaseStream.Read(bytes);
            return new ReadResult<BigInteger>(new BigInteger(bytes));
        }

        public ReadResult<T> ReadObject<T>(bool isNaked = false) where T : IObject
        {
            if (isNaked)
            {
                return ReadNakedObject<T>(typeof(T));
            }
            else
            {
                return ReadResult<T>.Move(ReadObject());
            }
        }

        private ReadResult<T> ReadNakedObject<T>(Type type)
        {
            var checkProvider = CheckProviderNull<T>();
            if (checkProvider.IsError)
            {
                return checkProvider;
            }

            var instance = _provider!.GetNakedFromType(type);
            if (instance is null)
            {
                return new ReadResult<T>($"No naked object of type {type} was found", ParserErrors.InvalidType);
            }

            var parsed = InternalReadObject(instance);
            return ReadResult<T>.Move(parsed);
        }

        public ReadResult<IObject> ReadObject()
        {
            var checkProvider = CheckProviderNull<IObject>();
            if (checkProvider.IsError)
            {
                return checkProvider;
            }

            var checkLength = CheckLength<IObject>(sizeof(int));
            if (checkLength.IsError)
            {
                return checkLength;
            }

            var constructorId = _reader.ReadInt32();
            var instance = _provider!.ResolveConstructorId(constructorId);
            if (instance == null)
            {
                return new ReadResult<IObject>($"No object with constructor id {constructorId} was found", ParserErrors.InvalidConstructor);
            }

            return InternalReadObject(instance);
        }

        private ReadResult<IObject> InternalReadObject(IObject instance)
        {
            var constructorId = instance.GetConstructorId();
            if (constructorId == _provider!.GzipPackedId)
            {
                instance.Deserialize(this);
                var gzippedBytes = _provider.GetGzippedBytes(instance);
                if (gzippedBytes.IsError)
                {
                    return ReadResult<IObject>.Move(gzippedBytes);
                }

                return GzipTools.DeserializeGzippedObject(gzippedBytes.Value, _provider);
            }
            else
            {
                foreach (var parser in _customParsers)
                {
                    if (parser.CanReadObject(instance))
                    {
                        return parser.ReadObject(instance, this);
                    }
                }

                return instance.Deserialize(this);
            }
        }

        public ReadResult<List<T>> ReadVector<T>(ParserTypes type, bool nakedVector = false, bool nakedObjects = false)
        {
            Type? getType = null;
            if (!nakedVector)
            {
                var checkProvider = CheckProviderNull<List<T>>();
                if (checkProvider.IsError)
                {
                    return checkProvider;
                }

                var getId = ReadInt32();
                if (getId.IsError)
                {
                    return ReadResult<List<T>>.Move(getId);
                }

                if (getId.Value != _provider!.VectorId)
                {
                    return new ReadResult<List<T>>("Constructor id is not a vector", ParserErrors.InvalidConstructor);
                }
            }
            else
            {
                getType = typeof(T);
            }

            var getSize = ReadInt32();
            if (getSize.IsError)
            {
                return ReadResult<List<T>>.Move(getSize);
            }

            var size = getSize.Value;
            var list = new List<T>();
            for (var i = 0; i < size; i++)
            {
                ReadResult<object> result;
                if (nakedObjects && type is not ParserTypes.Object)
                {
                    return new ReadResult<List<T>>("Trying to parse a naked object but provided type is not an object", ParserErrors.InvalidType);
                }
                else if (nakedObjects)
                {
                    result = ReadResult<object>.Move(ReadNakedObject<IObject>(getType!));
                }
                else
                {
                    result = Read(type);
                }

                if (result.IsError)
                {
                    return ReadResult<List<T>>.Move(result);
                }

                if (result.Value is T casted)
                {
                    list.Add(casted);
                }
                else
                {
                    return new ReadResult<List<T>>($"Expected type {typeof(T)} but {result.Value.GetType()} was deserialized", ParserErrors.InvalidType);
                }
            }

            return new ReadResult<List<T>>(list);
        }

        public ReadResult<object> Read(ParserTypes type)
        {
            switch (type)
            {
                case ParserTypes.Int:
                    return ReadResult<object>.Move(ReadInt32());
                case ParserTypes.Int64:
                    return ReadResult<object>.Move(ReadInt64());
                case ParserTypes.Double:
                    return ReadResult<object>.Move(ReadDouble());
                case ParserTypes.Byte:
                    return ReadResult<object>.Move(ReadByte());
                case ParserTypes.Bytes:
                    return ReadResult<object>.Move(ReadBytes());
                case ParserTypes.String:
                    return ReadResult<object>.Move(ReadBytes());
                case ParserTypes.Bool:
                    return ReadResult<object>.Move(ReadBool());
                case ParserTypes.Object:
                    return ReadResult<object>.Move(ReadObject());
                default:
                    return new ReadResult<object>("Unknown type", ParserErrors.InvalidType);
            }
        }

        public ReadResult<T> Read<T>(ParserTypes type)
        {
            return ReadResult<T>.Move(Read(type));
        }

        public ReadResult<T> CheckLength<T>(int length)
        {
            if (_reader.BaseStream.Length - _reader.BaseStream.Position < length)
            {
                return new ReadResult<T>($"Remaining bytes are less than {length}", Results.ParserErrors.StreamTooShort);
            }

            return ReadResult<T>.GetFakeResult();
        }

        private ReadResult<T> CheckProviderNull<T>()
        {
            if (_provider is null)
            {
                return new ReadResult<T>($"Provider is null", ParserErrors.ProviderNull);
            }

            return ReadResult<T>.GetFakeResult();
        }


        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}
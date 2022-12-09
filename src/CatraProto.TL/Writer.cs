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
using System.Collections;
using System.IO;
using System.Numerics;
using System.Text;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    public class Writer : IDisposable
    {
        public Stream Stream
        {
            get => _writer.BaseStream;
        }

        private readonly ObjectProvider? _provider;
        private readonly BinaryWriter _writer;

        public Writer(ObjectProvider? provider, Stream stream, bool leaveOpen = false)
        {
            _provider = provider;
            _writer = new BinaryWriter(stream, Encoding.Default, leaveOpen);
        }

        public void WriteInt32(int value)
        {
            _writer.Write(value);
        }

        public void WriteInt64(long value)
        {
            _writer.Write(value);
        }

        public void WriteInt16(short value)
        {
            _writer.Write(value);
        }

        public void WriteUInt16(ushort value)
        {
            _writer.Write(value);
        }

        public void WriteDouble(double value)
        {
            _writer.Write(value);
        }

        public void WriteByte(byte value)
        {
            _writer.Write(value);
        }

        public WriteResult WriteBigInteger(BigInteger value)
        {
            var bArray = value.ToByteArray();
            if (bArray.Length % 4 != 0)
            {
                return new WriteResult($"BigInteger array is not divisible by 4, value is {bArray.Length}", ParserErrors.NotDivisible);
            }

            _writer.Write(bArray);
            return new WriteResult();
        }

        public WriteResult WriteObject(IObject value)
        {
            return value.Serialize(this);
        }

        public void WriteString(string value)
        {
            WriteBytes(Encoding.UTF8.GetBytes(value));
        }

        public WriteResult WriteBool(bool value)
        {
            var provNull = CheckProviderNull();
            if (provNull.IsError)
            {
                return provNull;
            }

            _writer.Write(value ? _provider!.BoolTrueId : _provider!.BoolFalseId);
            return new WriteResult();
        }

        public void WriteBytes(byte[] bytes)
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

        public WriteResult WriteVector(IList list, bool naked = false)
        {
            if (!naked)
            {
                var provNull = CheckProviderNull();
                if (provNull.IsError)
                {
                    return provNull;
                }

                WriteInt32(_provider!.VectorId);
            }

            WriteInt32(list.Count);
            foreach (var element in list)
            {
                var result = Write(element);
                if (result.IsError)
                {
                    return result;
                }
            }

            return new WriteResult();
        }

        public WriteResult Write(object value)
        {
            if (value == null)
            {
                return new WriteResult("Value is null", ParserErrors.NullValue);
            }

            switch (value)
            {
                case int i:
                    WriteInt32(i);
                    return new WriteResult();
                case long l:
                    WriteInt64(l);
                    return new WriteResult();
                case string s:
                    WriteString(s);
                    return new WriteResult();
                case double d:
                    WriteDouble(d);
                    return new WriteResult();
                case byte b:
                    WriteByte(b);
                    return new WriteResult();
                case byte[] bb:
                    WriteBytes(bb);
                    return new WriteResult();
                case bool b:
                    return WriteBool(b);
                case BigInteger bigInteger:
                    WriteBigInteger(bigInteger);
                    return new WriteResult();
                case IObject obj:
                    return WriteObject(obj);
                case IList list:
                    return WriteVector(list);
                default:
                    return new WriteResult($"{value.GetType()} type is not supported", ParserErrors.InvalidType);
            }
        }

        private WriteResult CheckProviderNull()
        {
            if (_provider is null)
            {
                return new WriteResult("Provider is null", ParserErrors.ProviderNull);
            }

            return new WriteResult();
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}
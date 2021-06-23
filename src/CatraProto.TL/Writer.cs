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
		private IObjectProvider _provider;

		private BinaryWriter _writer;

		public Writer(IObjectProvider provider, Stream stream, bool leaveOpen = false) : this(provider, stream, Encoding.UTF8, leaveOpen)
		{
		}

		public Writer(IObjectProvider provider, Stream stream, Encoding encoding, bool leaveOpen = false)
		{
			_provider = provider;
			_writer = new BinaryWriter(stream, encoding, leaveOpen);
		}

		public Stream Stream
		{
			get
			{
				_writer.Flush();
				return _writer.BaseStream;
			}
		}

		public void Dispose()
		{
			_writer?.Dispose();
		}

		public void Write<T>(T value)
		{
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
					_writer.Write(bigInteger.ToByteArray());
					break;
				case IObject obj:
					obj.Serialize(this);
					break;
				default:
					throw new SerializationException($"The type {typeof(T)} is not supported",
						SerializationException.SerializationErrors.TypeNotFound);
			}
		}

		private void WriteBool(bool value)
		{
			var type = value ? _provider.BoolTrue : _provider.BoolFalse;
			if (type == null)
			{
				throw new SerializationException("The provider returned a null value for BoolTrue or BoolFalse",
					SerializationException.SerializationErrors.BoolNull);
			}

			((IObject)Activator.CreateInstance(type))?.Serialize(this);
		}

		private void WriteBytes(byte[] bytes)
		{
			var arrayLenght = bytes.Length;
			var totalLenght = arrayLenght;
			if (arrayLenght <= 253)
			{
				_writer.Write((byte)arrayLenght);
				totalLenght++;

				_writer.Write(bytes);
			}
			else
			{
				_writer.Write((byte)254);
				_writer.Write((byte)arrayLenght);
				_writer.Write((byte)(arrayLenght >> 8));
				_writer.Write((byte)(arrayLenght >> 16));
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
			Write(_provider.VectorId);
			Write(list.Count);
			foreach (var element in list)
			{
				Write(element);
			}
		}
	}
}
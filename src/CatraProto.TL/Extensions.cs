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
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    public static class Extensions
    {
        public static WriteResult ToArray(this IObject obj, ObjectProvider objectProvider, out byte[] serialized)
        {
            using var writer = new Writer(objectProvider, new MemoryStream());
            var wResult = writer.WriteObject(obj);
            serialized = wResult.IsError ? Array.Empty<byte>() : ((MemoryStream)writer.Stream).ToArray();
            return wResult;
        }

        public static ReadResult<T> ToObject<T>(this Stream stream, ObjectProvider objectProvider) where T : IObject
        {
            using var reader = new Reader(objectProvider, stream, true);
            return reader.ReadObject<T>();
        }

        public static ReadResult<T> ToObject<T>(this byte[] array, ObjectProvider objectProvider) where T : IObject
        {
            using var ms = new MemoryStream(array);
            return ms.ToObject<T>(objectProvider);
        }

        public static ReadResult<List<T>> ToVector<T>(this byte[] array, ObjectProvider objectProvider) where T : IObject
        {
            using var ms = new MemoryStream(array);
            return ms.ToVector<T>(objectProvider);
        }

        public static ReadResult<List<T>> ToVector<T>(this Stream stream, ObjectProvider objectProvider) where T : IObject
        {
            using var reader = new Reader(objectProvider, stream, true);
            return reader.ReadVector<T>(ParserTypes.Object);
        }

        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }
    }
}
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using CatraProto.Client.Crypto;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CatraProto.Client.TL
{
    public static class TLExtensions
    {
        private static readonly TLNameSerializer _tlNameSerializer = new TLNameSerializer();
        public static string ToJson(this IObject obj, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(obj, formatting, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                SerializationBinder = _tlNameSerializer
            });
        }

        public static WriteResult ToRecyclableStream(this IObject obj, ObjectProvider provider, out MemoryStream? stream)
        {
            stream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using var writer = new Writer(provider, stream, true);
            var tryWrite = writer.WriteObject(obj);
            stream.Seek(0, SeekOrigin.Begin);
            if (tryWrite.IsError)
            {
                stream.Dispose();
                stream = null;
            }

            return tryWrite;
        }
    }
}
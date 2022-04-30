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

using System.IO;
using System.IO.Compression;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.TL
{
    internal static class GzipTools
    {
        public static MemoryStream ReadGzipPacket(byte[] compressedData)
        {
            var decompressedStream = new MemoryStream();
            using var stream = new GZipStream(compressedData.ToMemoryStream(), CompressionMode.Decompress);
            stream.CopyTo(decompressedStream);

            decompressedStream.Seek(0, SeekOrigin.Begin);
            return decompressedStream;
        }

        public static ReadResult<IObject> DeserializeGzippedObject(byte[] compressedData, ObjectProvider provider)
        {
            using var reader = new Reader(provider, ReadGzipPacket(compressedData));
            return reader.ReadObject();
        }
    }
}
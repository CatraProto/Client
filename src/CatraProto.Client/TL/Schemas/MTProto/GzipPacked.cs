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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GzipPacked : IObject
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 812830625; }

        [Newtonsoft.Json.JsonProperty("packed_data")]
        public byte[] PackedData { get; set; }


#nullable enable
        public GzipPacked(byte[] packedData)
        {
            PackedData = packedData;

        }
#nullable disable
        internal GzipPacked()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(PackedData);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypackedData = reader.ReadBytes();
            if (trypackedData.IsError)
            {
                return ReadResult<IObject>.Move(trypackedData);
            }
            PackedData = trypackedData.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "gzip_packed";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GzipPacked
            {
                PackedData = PackedData
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GzipPacked castedOther)
            {
                return true;
            }
            if (PackedData != castedOther.PackedData)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
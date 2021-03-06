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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class FileHash : CatraProto.Client.TL.Schemas.CloudChats.FileHashBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -207944868; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override long Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public sealed override int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public sealed override byte[] Hash { get; set; }


#nullable enable
        public FileHash(long offset, int limit, byte[] hash)
        {
            Offset = offset;
            Limit = limit;
            Hash = hash;

        }
#nullable disable
        internal FileHash()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Offset);
            writer.WriteInt32(Limit);

            writer.WriteBytes(Hash);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt64();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "fileHash";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FileHash
            {
                Offset = Offset,
                Limit = Limit,
                Hash = Hash
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not FileHash castedOther)
            {
                return true;
            }
            if (Offset != castedOther.Offset)
            {
                return true;
            }
            if (Limit != castedOther.Limit)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
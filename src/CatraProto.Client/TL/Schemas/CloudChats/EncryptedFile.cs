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
    public partial class EncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1248893260; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public int KeyFingerprint { get; set; }


#nullable enable
        public EncryptedFile(long id, long accessHash, int size, int dcId, int keyFingerprint)
        {
            Id = id;
            AccessHash = accessHash;
            Size = size;
            DcId = dcId;
            KeyFingerprint = keyFingerprint;

        }
#nullable disable
        internal EncryptedFile()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(Size);
            writer.WriteInt32(DcId);
            writer.WriteInt32(KeyFingerprint);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }
            AccessHash = tryaccessHash.Value;
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }
            Size = trysize.Value;
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }
            DcId = trydcId.Value;
            var trykeyFingerprint = reader.ReadInt32();
            if (trykeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trykeyFingerprint);
            }
            KeyFingerprint = trykeyFingerprint.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "encryptedFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedFile
            {
                Id = Id,
                AccessHash = AccessHash,
                Size = Size,
                DcId = DcId,
                KeyFingerprint = KeyFingerprint
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedFile castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }
            if (Size != castedOther.Size)
            {
                return true;
            }
            if (DcId != castedOther.DcId)
            {
                return true;
            }
            if (KeyFingerprint != castedOther.KeyFingerprint)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
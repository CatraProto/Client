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
    public partial class InputEncryptedFileUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1690108678; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public int KeyFingerprint { get; set; }


#nullable enable
        public InputEncryptedFileUploaded(long id, int parts, string md5Checksum, int keyFingerprint)
        {
            Id = id;
            Parts = parts;
            Md5Checksum = md5Checksum;
            KeyFingerprint = keyFingerprint;

        }
#nullable disable
        internal InputEncryptedFileUploaded()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt32(Parts);

            writer.WriteString(Md5Checksum);
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
            var tryparts = reader.ReadInt32();
            if (tryparts.IsError)
            {
                return ReadResult<IObject>.Move(tryparts);
            }
            Parts = tryparts.Value;
            var trymd5Checksum = reader.ReadString();
            if (trymd5Checksum.IsError)
            {
                return ReadResult<IObject>.Move(trymd5Checksum);
            }
            Md5Checksum = trymd5Checksum.Value;
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
            return "inputEncryptedFileUploaded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputEncryptedFileUploaded
            {
                Id = Id,
                Parts = Parts,
                Md5Checksum = Md5Checksum,
                KeyFingerprint = KeyFingerprint
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputEncryptedFileUploaded castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (Parts != castedOther.Parts)
            {
                return true;
            }
            if (Md5Checksum != castedOther.Md5Checksum)
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
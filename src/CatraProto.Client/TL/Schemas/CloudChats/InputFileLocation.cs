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
    public partial class InputFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -539317279; }

        [Newtonsoft.Json.JsonProperty("volume_id")]
        public long VolumeId { get; set; }

        [Newtonsoft.Json.JsonProperty("local_id")]
        public int LocalId { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public long Secret { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }


#nullable enable
        public InputFileLocation(long volumeId, int localId, long secret, byte[] fileReference)
        {
            VolumeId = volumeId;
            LocalId = localId;
            Secret = secret;
            FileReference = fileReference;

        }
#nullable disable
        internal InputFileLocation()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(VolumeId);
            writer.WriteInt32(LocalId);
            writer.WriteInt64(Secret);

            writer.WriteBytes(FileReference);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvolumeId = reader.ReadInt64();
            if (tryvolumeId.IsError)
            {
                return ReadResult<IObject>.Move(tryvolumeId);
            }
            VolumeId = tryvolumeId.Value;
            var trylocalId = reader.ReadInt32();
            if (trylocalId.IsError)
            {
                return ReadResult<IObject>.Move(trylocalId);
            }
            LocalId = trylocalId.Value;
            var trysecret = reader.ReadInt64();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }
            Secret = trysecret.Value;
            var tryfileReference = reader.ReadBytes();
            if (tryfileReference.IsError)
            {
                return ReadResult<IObject>.Move(tryfileReference);
            }
            FileReference = tryfileReference.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputFileLocation
            {
                VolumeId = VolumeId,
                LocalId = LocalId,
                Secret = Secret,
                FileReference = FileReference
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputFileLocation castedOther)
            {
                return true;
            }
            if (VolumeId != castedOther.VolumeId)
            {
                return true;
            }
            if (LocalId != castedOther.LocalId)
            {
                return true;
            }
            if (Secret != castedOther.Secret)
            {
                return true;
            }
            if (FileReference != castedOther.FileReference)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
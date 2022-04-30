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
    public partial class CdnPublicKey : CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -914167110; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public sealed override int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("public_key")]
        public sealed override string PublicKey { get; set; }


#nullable enable
        public CdnPublicKey(int dcId, string publicKey)
        {
            DcId = dcId;
            PublicKey = publicKey;

        }
#nullable disable
        internal CdnPublicKey()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);

            writer.WriteString(PublicKey);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }
            DcId = trydcId.Value;
            var trypublicKey = reader.ReadString();
            if (trypublicKey.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKey);
            }
            PublicKey = trypublicKey.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "cdnPublicKey";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CdnPublicKey
            {
                DcId = DcId,
                PublicKey = PublicKey
            };
            return newClonedObject;

        }
#nullable disable
    }
}
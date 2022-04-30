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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class CdnConfig : CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1462101002; }

        [Newtonsoft.Json.JsonProperty("public_keys")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> PublicKeys { get; set; }


#nullable enable
        public CdnConfig(List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> publicKeys)
        {
            PublicKeys = publicKeys;

        }
#nullable disable
        internal CdnConfig()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpublicKeys = writer.WriteVector(PublicKeys, false);
            if (checkpublicKeys.IsError)
            {
                return checkpublicKeys;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypublicKeys = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypublicKeys.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKeys);
            }
            PublicKeys = trypublicKeys.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "cdnConfig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CdnConfig();
            foreach (var publicKeys in PublicKeys)
            {
                var clonepublicKeys = (CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase?)publicKeys.Clone();
                if (clonepublicKeys is null)
                {
                    return null;
                }
                newClonedObject.PublicKeys.Add(clonepublicKeys);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
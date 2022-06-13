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
    public partial class MessageActionSecureValuesSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -648257196; }

        [Newtonsoft.Json.JsonProperty("types")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> Types { get; set; }


#nullable enable
        public MessageActionSecureValuesSent(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types)
        {
            Types = types;

        }
#nullable disable
        internal MessageActionSecureValuesSent()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktypes = writer.WriteVector(Types, false);
            if (checktypes.IsError)
            {
                return checktypes;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytypes.IsError)
            {
                return ReadResult<IObject>.Move(trytypes);
            }
            Types = trytypes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionSecureValuesSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionSecureValuesSent
            {
                Types = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>()
            };
            foreach (var types in Types)
            {
                var clonetypes = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)types.Clone();
                if (clonetypes is null)
                {
                    return null;
                }
                newClonedObject.Types.Add(clonetypes);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
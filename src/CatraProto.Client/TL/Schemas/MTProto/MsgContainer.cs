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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgContainer : CatraProto.Client.TL.Schemas.MTProto.MessageContainerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1945237724; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<CatraProto.Client.TL.Schemas.MTProto.Message> Messages { get; set; }


#nullable enable
        public MsgContainer(List<CatraProto.Client.TL.Schemas.MTProto.Message> messages)
        {
            Messages = messages;

        }
#nullable disable
        internal MsgContainer()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessages = writer.WriteVector(Messages, true);
            if (checkmessages.IsError)
            {
                return checkmessages;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessages = reader.ReadVector<CatraProto.Client.TL.Schemas.MTProto.Message>(ParserTypes.Object, nakedVector: true, nakedObjects: true);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }
            Messages = trymessages.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msg_container";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgContainer();
            foreach (var messages in Messages)
            {
                var clonemessages = (CatraProto.Client.TL.Schemas.MTProto.Message?)messages.Clone();
                if (clonemessages is null)
                {
                    return null;
                }
                newClonedObject.Messages.Add(clonemessages);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
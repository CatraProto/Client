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
    public partial class MsgCopy : CatraProto.Client.TL.Schemas.MTProto.MessageCopyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -530561358; }

        [Newtonsoft.Json.JsonProperty("orig_message")]
        public sealed override CatraProto.Client.TL.Schemas.MTProto.MessageBase OrigMessage { get; set; }


#nullable enable
        public MsgCopy(CatraProto.Client.TL.Schemas.MTProto.MessageBase origMessage)
        {
            OrigMessage = origMessage;

        }
#nullable disable
        internal MsgCopy()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkorigMessage = writer.WriteObject(OrigMessage);
            if (checkorigMessage.IsError)
            {
                return checkorigMessage;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryorigMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.MTProto.MessageBase>();
            if (tryorigMessage.IsError)
            {
                return ReadResult<IObject>.Move(tryorigMessage);
            }
            OrigMessage = tryorigMessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msg_copy";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgCopy();
            var cloneOrigMessage = (CatraProto.Client.TL.Schemas.MTProto.MessageBase?)OrigMessage.Clone();
            if (cloneOrigMessage is null)
            {
                return null;
            }
            newClonedObject.OrigMessage = cloneOrigMessage;
            return newClonedObject;

        }
#nullable disable
    }
}
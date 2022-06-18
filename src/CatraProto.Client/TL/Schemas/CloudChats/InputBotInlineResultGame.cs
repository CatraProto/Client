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
    public partial class InputBotInlineResultGame : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1336154098; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public InputBotInlineResultGame(string id, string shortName, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            ShortName = shortName;
            SendMessage = sendMessage;

        }
#nullable disable
        internal InputBotInlineResultGame()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(ShortName);
            var checksendMessage = writer.WriteObject(SendMessage);
            if (checksendMessage.IsError)
            {
                return checksendMessage;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            var trysendMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();
            if (trysendMessage.IsError)
            {
                return ReadResult<IObject>.Move(trysendMessage);
            }
            SendMessage = trysendMessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputBotInlineResultGame";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineResultGame
            {
                Id = Id,
                ShortName = ShortName
            };
            var cloneSendMessage = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase?)SendMessage.Clone();
            if (cloneSendMessage is null)
            {
                return null;
            }
            newClonedObject.SendMessage = cloneSendMessage;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputBotInlineResultGame castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (ShortName != castedOther.ShortName)
            {
                return true;
            }
            if (SendMessage.Compare(castedOther.SendMessage))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
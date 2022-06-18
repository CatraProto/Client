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

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SetBotMenuButton : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1157944655; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("button")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase Button { get; set; }


#nullable enable
        public SetBotMenuButton(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase button)
        {
            UserId = userId;
            Button = button;

        }
#nullable disable

        internal SetBotMenuButton()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }
            var checkbutton = writer.WriteObject(Button);
            if (checkbutton.IsError)
            {
                return checkbutton;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trybutton = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase>();
            if (trybutton.IsError)
            {
                return ReadResult<IObject>.Move(trybutton);
            }
            Button = trybutton.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "bots.setBotMenuButton";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotMenuButton();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }
            newClonedObject.UserId = cloneUserId;
            var cloneButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)Button.Clone();
            if (cloneButton is null)
            {
                return null;
            }
            newClonedObject.Button = cloneButton;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotMenuButton castedOther)
            {
                return true;
            }
            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }
            if (Button.Compare(castedOther.Button))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}
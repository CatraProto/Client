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
    public partial class UpdateBotMenuButton : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 347625491; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("button")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase Button { get; set; }


#nullable enable
        public UpdateBotMenuButton(long botId, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase button)
        {
            BotId = botId;
            Button = button;

        }
#nullable disable
        internal UpdateBotMenuButton()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BotId);
            var checkbutton = writer.WriteObject(Button);
            if (checkbutton.IsError)
            {
                return checkbutton;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }
            BotId = trybotId.Value;
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
            return "updateBotMenuButton";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotMenuButton
            {
                BotId = BotId
            };
            var cloneButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)Button.Clone();
            if (cloneButton is null)
            {
                return null;
            }
            newClonedObject.Button = cloneButton;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotMenuButton castedOther)
            {
                return true;
            }
            if (BotId != castedOther.BotId)
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
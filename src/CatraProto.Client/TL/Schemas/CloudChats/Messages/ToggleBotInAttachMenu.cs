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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ToggleBotInAttachMenu : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 451818415; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("bot")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled")]
        public bool Enabled { get; set; }


#nullable enable
        public ToggleBotInAttachMenu(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, bool enabled)
        {
            Bot = bot;
            Enabled = enabled;

        }
#nullable disable

        internal ToggleBotInAttachMenu()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }
            var checkenabled = writer.WriteBool(Enabled);
            if (checkenabled.IsError)
            {
                return checkenabled;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }
            Bot = trybot.Value;
            var tryenabled = reader.ReadBool();
            if (tryenabled.IsError)
            {
                return ReadResult<IObject>.Move(tryenabled);
            }
            Enabled = tryenabled.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.toggleBotInAttachMenu";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleBotInAttachMenu();
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }
            newClonedObject.Bot = cloneBot;
            newClonedObject.Enabled = Enabled;
            return newClonedObject;

        }
#nullable disable
    }
}
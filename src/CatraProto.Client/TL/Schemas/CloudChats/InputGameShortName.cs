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
    public partial class InputGameShortName : CatraProto.Client.TL.Schemas.CloudChats.InputGameBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1020139510; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


#nullable enable
        public InputGameShortName(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase botId, string shortName)
        {
            BotId = botId;
            ShortName = shortName;

        }
#nullable disable
        internal InputGameShortName()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbotId = writer.WriteObject(BotId);
            if (checkbotId.IsError)
            {
                return checkbotId;
            }

            writer.WriteString(ShortName);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }
            BotId = trybotId.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputGameShortName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputGameShortName();
            var cloneBotId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)BotId.Clone();
            if (cloneBotId is null)
            {
                return null;
            }
            newClonedObject.BotId = cloneBotId;
            newClonedObject.ShortName = ShortName;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputGameShortName castedOther)
            {
                return true;
            }
            if (BotId.Compare(castedOther.BotId))
            {
                return true;
            }
            if (ShortName != castedOther.ShortName)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
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
    public partial class BotInfo : CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -468280483; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("commands")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        [Newtonsoft.Json.JsonProperty("menu_button")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase MenuButton { get; set; }


#nullable enable
        public BotInfo(long userId, string description, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase menuButton)
        {
            UserId = userId;
            Description = description;
            Commands = commands;
            MenuButton = menuButton;

        }
#nullable disable
        internal BotInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            writer.WriteString(Description);
            var checkcommands = writer.WriteVector(Commands, false);
            if (checkcommands.IsError)
            {
                return checkcommands;
            }
            var checkmenuButton = writer.WriteObject(MenuButton);
            if (checkmenuButton.IsError)
            {
                return checkmenuButton;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }
            Description = trydescription.Value;
            var trycommands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycommands.IsError)
            {
                return ReadResult<IObject>.Move(trycommands);
            }
            Commands = trycommands.Value;
            var trymenuButton = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase>();
            if (trymenuButton.IsError)
            {
                return ReadResult<IObject>.Move(trymenuButton);
            }
            MenuButton = trymenuButton.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "botInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInfo
            {
                UserId = UserId,
                Description = Description,
                Commands = new List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>()
            };
            foreach (var commands in Commands)
            {
                var clonecommands = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase?)commands.Clone();
                if (clonecommands is null)
                {
                    return null;
                }
                newClonedObject.Commands.Add(clonecommands);
            }
            var cloneMenuButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)MenuButton.Clone();
            if (cloneMenuButton is null)
            {
                return null;
            }
            newClonedObject.MenuButton = cloneMenuButton;
            return newClonedObject;

        }
#nullable disable
    }
}
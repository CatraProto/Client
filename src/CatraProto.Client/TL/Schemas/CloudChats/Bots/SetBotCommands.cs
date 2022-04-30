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

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SetBotCommands : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 85399130; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("scope")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase Scope { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("commands")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }


#nullable enable
        public SetBotCommands(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands)
        {
            Scope = scope;
            LangCode = langCode;
            Commands = commands;

        }
#nullable disable

        internal SetBotCommands()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkscope = writer.WriteObject(Scope);
            if (checkscope.IsError)
            {
                return checkscope;
            }

            writer.WriteString(LangCode);
            var checkcommands = writer.WriteVector(Commands, false);
            if (checkcommands.IsError)
            {
                return checkcommands;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryscope = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase>();
            if (tryscope.IsError)
            {
                return ReadResult<IObject>.Move(tryscope);
            }
            Scope = tryscope.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            var trycommands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycommands.IsError)
            {
                return ReadResult<IObject>.Move(trycommands);
            }
            Commands = trycommands.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "bots.setBotCommands";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotCommands();
            var cloneScope = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase?)Scope.Clone();
            if (cloneScope is null)
            {
                return null;
            }
            newClonedObject.Scope = cloneScope;
            newClonedObject.LangCode = LangCode;
            foreach (var commands in Commands)
            {
                var clonecommands = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase?)commands.Clone();
                if (clonecommands is null)
                {
                    return null;
                }
                newClonedObject.Commands.Add(clonecommands);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
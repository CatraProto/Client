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

using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class AttachMenuBot : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inactive = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -381896846; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inactive")]
        public sealed override bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("icons")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> Icons { get; set; }


#nullable enable
        public AttachMenuBot(long botId, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> icons)
        {
            BotId = botId;
            ShortName = shortName;
            Icons = icons;

        }
#nullable disable
        internal AttachMenuBot()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inactive ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(BotId);

            writer.WriteString(ShortName);
            var checkicons = writer.WriteVector(Icons, false);
            if (checkicons.IsError)
            {
                return checkicons;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Inactive = FlagsHelper.IsFlagSet(Flags, 0);
            var trybotId = reader.ReadInt64();
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
            var tryicons = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryicons.IsError)
            {
                return ReadResult<IObject>.Move(tryicons);
            }
            Icons = tryicons.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "attachMenuBot";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBot
            {
                Flags = Flags,
                Inactive = Inactive,
                BotId = BotId,
                ShortName = ShortName,
                Icons = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase>()
            };
            foreach (var icons in Icons)
            {
                var cloneicons = (CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase?)icons.Clone();
                if (cloneicons is null)
                {
                    return null;
                }
                newClonedObject.Icons.Add(cloneicons);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
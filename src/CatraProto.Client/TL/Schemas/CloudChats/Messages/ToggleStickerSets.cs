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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ToggleStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Uninstall = 1 << 0,
            Archive = 1 << 1,
            Unarchive = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1257951254; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("uninstall")]
        public bool Uninstall { get; set; }

        [Newtonsoft.Json.JsonProperty("archive")]
        public bool Archive { get; set; }

        [Newtonsoft.Json.JsonProperty("unarchive")]
        public bool Unarchive { get; set; }

        [Newtonsoft.Json.JsonProperty("stickersets")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> Stickersets { get; set; }


#nullable enable
        public ToggleStickerSets(List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets)
        {
            Stickersets = stickersets;

        }
#nullable disable

        internal ToggleStickerSets()
        {
        }

        public void UpdateFlags()
        {
            Flags = Uninstall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Archive ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Unarchive ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkstickersets = writer.WriteVector(Stickersets, false);
            if (checkstickersets.IsError)
            {
                return checkstickersets;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Uninstall = FlagsHelper.IsFlagSet(Flags, 0);
            Archive = FlagsHelper.IsFlagSet(Flags, 1);
            Unarchive = FlagsHelper.IsFlagSet(Flags, 2);
            var trystickersets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickersets.IsError)
            {
                return ReadResult<IObject>.Move(trystickersets);
            }
            Stickersets = trystickersets.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.toggleStickerSets";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleStickerSets
            {
                Flags = Flags,
                Uninstall = Uninstall,
                Archive = Archive,
                Unarchive = Unarchive,
                Stickersets = new List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>()
            };
            foreach (var stickersets in Stickersets)
            {
                var clonestickersets = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)stickersets.Clone();
                if (clonestickersets is null)
                {
                    return null;
                }
                newClonedObject.Stickersets.Add(clonestickersets);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
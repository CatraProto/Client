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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class GlobalPrivacySettings : CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ArchiveAndMuteNewNoncontactPeers = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1096616924; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("archive_and_mute_new_noncontact_peers")]
        public sealed override bool? ArchiveAndMuteNewNoncontactPeers { get; set; }



        public GlobalPrivacySettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ArchiveAndMuteNewNoncontactPeers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkarchiveAndMuteNewNoncontactPeers = writer.WriteBool(ArchiveAndMuteNewNoncontactPeers.Value);
                if (checkarchiveAndMuteNewNoncontactPeers.IsError)
                {
                    return checkarchiveAndMuteNewNoncontactPeers;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryarchiveAndMuteNewNoncontactPeers = reader.ReadBool();
                if (tryarchiveAndMuteNewNoncontactPeers.IsError)
                {
                    return ReadResult<IObject>.Move(tryarchiveAndMuteNewNoncontactPeers);
                }
                ArchiveAndMuteNewNoncontactPeers = tryarchiveAndMuteNewNoncontactPeers.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "globalPrivacySettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GlobalPrivacySettings
            {
                Flags = Flags,
                ArchiveAndMuteNewNoncontactPeers = ArchiveAndMuteNewNoncontactPeers
            };
            return newClonedObject;

        }
#nullable disable
    }
}
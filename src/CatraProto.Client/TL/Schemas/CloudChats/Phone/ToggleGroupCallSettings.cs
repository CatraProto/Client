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

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ToggleGroupCallSettings : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ResetInviteHash = 1 << 1,
            JoinMuted = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1958458429; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("reset_invite_hash")]
        public bool ResetInviteHash { get; set; }

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("join_muted")]
        public bool? JoinMuted { get; set; }


#nullable enable
        public ToggleGroupCallSettings(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;

        }
#nullable disable

        internal ToggleGroupCallSettings()
        {
        }

        public void UpdateFlags()
        {
            Flags = ResetInviteHash ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = JoinMuted == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkjoinMuted = writer.WriteBool(JoinMuted.Value);
                if (checkjoinMuted.IsError)
                {
                    return checkjoinMuted;
                }
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
            ResetInviteHash = FlagsHelper.IsFlagSet(Flags, 1);
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryjoinMuted = reader.ReadBool();
                if (tryjoinMuted.IsError)
                {
                    return ReadResult<IObject>.Move(tryjoinMuted);
                }
                JoinMuted = tryjoinMuted.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.toggleGroupCallSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleGroupCallSettings
            {
                Flags = Flags,
                ResetInviteHash = ResetInviteHash
            };
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }
            newClonedObject.Call = cloneCall;
            newClonedObject.JoinMuted = JoinMuted;
            return newClonedObject;

        }
#nullable disable
    }
}
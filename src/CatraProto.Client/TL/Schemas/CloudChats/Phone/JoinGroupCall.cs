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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class JoinGroupCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Muted = 1 << 0,
            VideoStopped = 1 << 2,
            InviteHash = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1322057861; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("muted")]
        public bool Muted { get; set; }

        [Newtonsoft.Json.JsonProperty("video_stopped")]
        public bool VideoStopped { get; set; }

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("join_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase JoinAs { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("invite_hash")]
        public string InviteHash { get; set; }

        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


#nullable enable
        public JoinGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase joinAs, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
        {
            Call = call;
            JoinAs = joinAs;
            Params = pparams;

        }
#nullable disable

        internal JoinGroupCall()
        {
        }

        public void UpdateFlags()
        {
            Flags = Muted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = VideoStopped ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = InviteHash == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

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
            var checkjoinAs = writer.WriteObject(JoinAs);
            if (checkjoinAs.IsError)
            {
                return checkjoinAs;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(InviteHash);
            }

            var checkpparams = writer.WriteObject(Params);
            if (checkpparams.IsError)
            {
                return checkpparams;
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
            Muted = FlagsHelper.IsFlagSet(Flags, 0);
            VideoStopped = FlagsHelper.IsFlagSet(Flags, 2);
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            var tryjoinAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryjoinAs.IsError)
            {
                return ReadResult<IObject>.Move(tryjoinAs);
            }
            JoinAs = tryjoinAs.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryinviteHash = reader.ReadString();
                if (tryinviteHash.IsError)
                {
                    return ReadResult<IObject>.Move(tryinviteHash);
                }
                InviteHash = tryinviteHash.Value;
            }

            var trypparams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trypparams.IsError)
            {
                return ReadResult<IObject>.Move(trypparams);
            }
            Params = trypparams.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.joinGroupCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new JoinGroupCall
            {
                Flags = Flags,
                Muted = Muted,
                VideoStopped = VideoStopped
            };
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }
            newClonedObject.Call = cloneCall;
            var cloneJoinAs = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)JoinAs.Clone();
            if (cloneJoinAs is null)
            {
                return null;
            }
            newClonedObject.JoinAs = cloneJoinAs;
            newClonedObject.InviteHash = InviteHash;
            var cloneParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Params.Clone();
            if (cloneParams is null)
            {
                return null;
            }
            newClonedObject.Params = cloneParams;
            return newClonedObject;

        }
#nullable disable
    }
}
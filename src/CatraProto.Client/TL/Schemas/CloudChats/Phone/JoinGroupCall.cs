using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1322057861; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("muted")]
        public bool Muted { get; set; }

        [Newtonsoft.Json.JsonProperty("video_stopped")]
        public bool VideoStopped { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

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
            var newClonedObject = new JoinGroupCall();
            newClonedObject.Flags = Flags;
            newClonedObject.Muted = Muted;
            newClonedObject.VideoStopped = VideoStopped;
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

        public bool Compare(IObject other)
        {
            if (other is not JoinGroupCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Muted != castedOther.Muted)
            {
                return true;
            }

            if (VideoStopped != castedOther.VideoStopped)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (JoinAs.Compare(castedOther.JoinAs))
            {
                return true;
            }

            if (InviteHash != castedOther.InviteHash)
            {
                return true;
            }

            if (Params.Compare(castedOther.Params))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
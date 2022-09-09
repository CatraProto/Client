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
    public partial class DiscardCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1295269440; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("connection_id")]
        public long ConnectionId { get; set; }


#nullable enable
        public DiscardCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int duration, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason, long connectionId)
        {
            Peer = peer;
            Duration = duration;
            Reason = reason;
            ConnectionId = connectionId;
        }
#nullable disable

        internal DiscardCall()
        {
        }

        public void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Duration);
            var checkreason = writer.WriteObject(Reason);
            if (checkreason.IsError)
            {
                return checkreason;
            }

            writer.WriteInt64(ConnectionId);

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
            Video = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryduration = reader.ReadInt32();
            if (tryduration.IsError)
            {
                return ReadResult<IObject>.Move(tryduration);
            }

            Duration = tryduration.Value;
            var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }

            Reason = tryreason.Value;
            var tryconnectionId = reader.ReadInt64();
            if (tryconnectionId.IsError)
            {
                return ReadResult<IObject>.Move(tryconnectionId);
            }

            ConnectionId = tryconnectionId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.discardCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DiscardCall();
            newClonedObject.Flags = Flags;
            newClonedObject.Video = Video;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Duration = Duration;
            var cloneReason = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase?)Reason.Clone();
            if (cloneReason is null)
            {
                return null;
            }

            newClonedObject.Reason = cloneReason;
            newClonedObject.ConnectionId = ConnectionId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DiscardCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Video != castedOther.Video)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Duration != castedOther.Duration)
            {
                return true;
            }

            if (Reason.Compare(castedOther.Reason))
            {
                return true;
            }

            if (ConnectionId != castedOther.ConnectionId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
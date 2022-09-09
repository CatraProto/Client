using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 2,
            Reason = 1 << 0,
            Duration = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2132731265; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("call_id")]
        public long CallId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }


#nullable enable
        public MessageActionPhoneCall(long callId)
        {
            CallId = callId;
        }
#nullable disable
        internal MessageActionPhoneCall()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Reason == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(CallId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkreason = writer.WriteObject(Reason);
                if (checkreason.IsError)
                {
                    return checkreason;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Duration.Value);
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
            Video = FlagsHelper.IsFlagSet(Flags, 2);
            var trycallId = reader.ReadInt64();
            if (trycallId.IsError)
            {
                return ReadResult<IObject>.Move(trycallId);
            }

            CallId = trycallId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
                if (tryreason.IsError)
                {
                    return ReadResult<IObject>.Move(tryreason);
                }

                Reason = tryreason.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryduration = reader.ReadInt32();
                if (tryduration.IsError)
                {
                    return ReadResult<IObject>.Move(tryduration);
                }

                Duration = tryduration.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionPhoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionPhoneCall();
            newClonedObject.Flags = Flags;
            newClonedObject.Video = Video;
            newClonedObject.CallId = CallId;
            if (Reason is not null)
            {
                var cloneReason = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase?)Reason.Clone();
                if (cloneReason is null)
                {
                    return null;
                }

                newClonedObject.Reason = cloneReason;
            }

            newClonedObject.Duration = Duration;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionPhoneCall castedOther)
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

            if (CallId != castedOther.CallId)
            {
                return true;
            }

            if (Reason is null && castedOther.Reason is not null || Reason is not null && castedOther.Reason is null)
            {
                return true;
            }

            if (Reason is not null && castedOther.Reason is not null && Reason.Compare(castedOther.Reason))
            {
                return true;
            }

            if (Duration != castedOther.Duration)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
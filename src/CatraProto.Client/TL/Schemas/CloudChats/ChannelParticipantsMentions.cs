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
    public partial class ChannelParticipantsMentions : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Q = 1 << 0,
            TopMsgId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -531931925; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("q")]
        public string Q { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int? TopMsgId { get; set; }


        public ChannelParticipantsMentions()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Q == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Q);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(TopMsgId.Value);
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
                var tryq = reader.ReadString();
                if (tryq.IsError)
                {
                    return ReadResult<IObject>.Move(tryq);
                }

                Q = tryq.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytopMsgId = reader.ReadInt32();
                if (trytopMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trytopMsgId);
                }

                TopMsgId = trytopMsgId.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantsMentions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantsMentions();
            newClonedObject.Flags = Flags;
            newClonedObject.Q = Q;
            newClonedObject.TopMsgId = TopMsgId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantsMentions castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
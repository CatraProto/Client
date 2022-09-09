using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendMultiMedia : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 5,
            Background = 1 << 6,
            ClearDraft = 1 << 7,
            Noforwards = 1 << 14,
            ReplyToMsgId = 1 << 0,
            ScheduleDate = 1 << 10,
            SendAs = 1 << 13
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -134016113; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("background")]
        public bool Background { get; set; }

        [Newtonsoft.Json.JsonProperty("clear_draft")]
        public bool ClearDraft { get; set; }

        [Newtonsoft.Json.JsonProperty("noforwards")]
        public bool Noforwards { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int? ReplyToMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("multi_media")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> MultiMedia { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_date")]
        public int? ScheduleDate { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("send_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }


#nullable enable
        public SendMultiMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> multiMedia)
        {
            Peer = peer;
            MultiMedia = multiMedia;
        }
#nullable disable

        internal SendMultiMedia()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = SendAs == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
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

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ReplyToMsgId.Value);
            }

            var checkmultiMedia = writer.WriteVector(MultiMedia, false);
            if (checkmultiMedia.IsError)
            {
                return checkmultiMedia;
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.WriteInt32(ScheduleDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var checksendAs = writer.WriteObject(SendAs);
                if (checksendAs.IsError)
                {
                    return checksendAs;
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
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            Background = FlagsHelper.IsFlagSet(Flags, 6);
            ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
            Noforwards = FlagsHelper.IsFlagSet(Flags, 14);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreplyToMsgId = reader.ReadInt32();
                if (tryreplyToMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToMsgId);
                }

                ReplyToMsgId = tryreplyToMsgId.Value;
            }

            var trymultiMedia = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trymultiMedia.IsError)
            {
                return ReadResult<IObject>.Move(trymultiMedia);
            }

            MultiMedia = trymultiMedia.Value;
            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var tryscheduleDate = reader.ReadInt32();
                if (tryscheduleDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryscheduleDate);
                }

                ScheduleDate = tryscheduleDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var trysendAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (trysendAs.IsError)
                {
                    return ReadResult<IObject>.Move(trysendAs);
                }

                SendAs = trysendAs.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendMultiMedia";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendMultiMedia();
            newClonedObject.Flags = Flags;
            newClonedObject.Silent = Silent;
            newClonedObject.Background = Background;
            newClonedObject.ClearDraft = ClearDraft;
            newClonedObject.Noforwards = Noforwards;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.ReplyToMsgId = ReplyToMsgId;
            newClonedObject.MultiMedia = new List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase>();
            foreach (var multiMedia in MultiMedia)
            {
                var clonemultiMedia = (CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase?)multiMedia.Clone();
                if (clonemultiMedia is null)
                {
                    return null;
                }

                newClonedObject.MultiMedia.Add(clonemultiMedia);
            }

            newClonedObject.ScheduleDate = ScheduleDate;
            if (SendAs is not null)
            {
                var cloneSendAs = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)SendAs.Clone();
                if (cloneSendAs is null)
                {
                    return null;
                }

                newClonedObject.SendAs = cloneSendAs;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendMultiMedia castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Background != castedOther.Background)
            {
                return true;
            }

            if (ClearDraft != castedOther.ClearDraft)
            {
                return true;
            }

            if (Noforwards != castedOther.Noforwards)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (ReplyToMsgId != castedOther.ReplyToMsgId)
            {
                return true;
            }

            var multiMediasize = castedOther.MultiMedia.Count;
            if (multiMediasize != MultiMedia.Count)
            {
                return true;
            }

            for (var i = 0; i < multiMediasize; i++)
            {
                if (castedOther.MultiMedia[i].Compare(MultiMedia[i]))
                {
                    return true;
                }
            }

            if (ScheduleDate != castedOther.ScheduleDate)
            {
                return true;
            }

            if (SendAs is null && castedOther.SendAs is not null || SendAs is not null && castedOther.SendAs is null)
            {
                return true;
            }

            if (SendAs is not null && castedOther.SendAs is not null && SendAs.Compare(castedOther.SendAs))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
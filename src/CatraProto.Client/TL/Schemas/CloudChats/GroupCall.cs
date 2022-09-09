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
    public partial class GroupCall : CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase
    {
        [Flags]
        public enum FlagsEnum
        {
            JoinMuted = 1 << 1,
            CanChangeJoinMuted = 1 << 2,
            JoinDateAsc = 1 << 6,
            ScheduleStartSubscribed = 1 << 8,
            CanStartVideo = 1 << 9,
            RecordVideoActive = 1 << 11,
            RtmpStream = 1 << 12,
            ListenersHidden = 1 << 13,
            Title = 1 << 3,
            StreamDcId = 1 << 4,
            RecordStartDate = 1 << 5,
            ScheduleDate = 1 << 7,
            UnmutedVideoCount = 1 << 10
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -711498484; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("join_muted")]
        public bool JoinMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("can_change_join_muted")]
        public bool CanChangeJoinMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("join_date_asc")]
        public bool JoinDateAsc { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_start_subscribed")]
        public bool ScheduleStartSubscribed { get; set; }

        [Newtonsoft.Json.JsonProperty("can_start_video")]
        public bool CanStartVideo { get; set; }

        [Newtonsoft.Json.JsonProperty("record_video_active")]
        public bool RecordVideoActive { get; set; }

        [Newtonsoft.Json.JsonProperty("rtmp_stream")]
        public bool RtmpStream { get; set; }

        [Newtonsoft.Json.JsonProperty("listeners_hidden")]
        public bool ListenersHidden { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("participants_count")]
        public int ParticipantsCount { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("stream_dc_id")]
        public int? StreamDcId { get; set; }

        [Newtonsoft.Json.JsonProperty("record_start_date")]
        public int? RecordStartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_date")]
        public int? ScheduleDate { get; set; }

        [Newtonsoft.Json.JsonProperty("unmuted_video_count")]
        public int? UnmutedVideoCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unmuted_video_limit")]
        public int UnmutedVideoLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public GroupCall(long id, long accessHash, int participantsCount, int unmutedVideoLimit, int version)
        {
            Id = id;
            AccessHash = accessHash;
            ParticipantsCount = participantsCount;
            UnmutedVideoLimit = unmutedVideoLimit;
            Version = version;
        }
#nullable disable
        internal GroupCall()
        {
        }

        public override void UpdateFlags()
        {
            Flags = JoinMuted ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = CanChangeJoinMuted ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = JoinDateAsc ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = ScheduleStartSubscribed ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = CanStartVideo ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
            Flags = RecordVideoActive ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = RtmpStream ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = ListenersHidden ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = StreamDcId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = RecordStartDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = UnmutedVideoCount == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(ParticipantsCount);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(StreamDcId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(RecordStartDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteInt32(ScheduleDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.WriteInt32(UnmutedVideoCount.Value);
            }

            writer.WriteInt32(UnmutedVideoLimit);
            writer.WriteInt32(Version);

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
            JoinMuted = FlagsHelper.IsFlagSet(Flags, 1);
            CanChangeJoinMuted = FlagsHelper.IsFlagSet(Flags, 2);
            JoinDateAsc = FlagsHelper.IsFlagSet(Flags, 6);
            ScheduleStartSubscribed = FlagsHelper.IsFlagSet(Flags, 8);
            CanStartVideo = FlagsHelper.IsFlagSet(Flags, 9);
            RecordVideoActive = FlagsHelper.IsFlagSet(Flags, 11);
            RtmpStream = FlagsHelper.IsFlagSet(Flags, 12);
            ListenersHidden = FlagsHelper.IsFlagSet(Flags, 13);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            var tryparticipantsCount = reader.ReadInt32();
            if (tryparticipantsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipantsCount);
            }

            ParticipantsCount = tryparticipantsCount.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trystreamDcId = reader.ReadInt32();
                if (trystreamDcId.IsError)
                {
                    return ReadResult<IObject>.Move(trystreamDcId);
                }

                StreamDcId = trystreamDcId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryrecordStartDate = reader.ReadInt32();
                if (tryrecordStartDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecordStartDate);
                }

                RecordStartDate = tryrecordStartDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryscheduleDate = reader.ReadInt32();
                if (tryscheduleDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryscheduleDate);
                }

                ScheduleDate = tryscheduleDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var tryunmutedVideoCount = reader.ReadInt32();
                if (tryunmutedVideoCount.IsError)
                {
                    return ReadResult<IObject>.Move(tryunmutedVideoCount);
                }

                UnmutedVideoCount = tryunmutedVideoCount.Value;
            }

            var tryunmutedVideoLimit = reader.ReadInt32();
            if (tryunmutedVideoLimit.IsError)
            {
                return ReadResult<IObject>.Move(tryunmutedVideoLimit);
            }

            UnmutedVideoLimit = tryunmutedVideoLimit.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }

            Version = tryversion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "groupCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCall();
            newClonedObject.Flags = Flags;
            newClonedObject.JoinMuted = JoinMuted;
            newClonedObject.CanChangeJoinMuted = CanChangeJoinMuted;
            newClonedObject.JoinDateAsc = JoinDateAsc;
            newClonedObject.ScheduleStartSubscribed = ScheduleStartSubscribed;
            newClonedObject.CanStartVideo = CanStartVideo;
            newClonedObject.RecordVideoActive = RecordVideoActive;
            newClonedObject.RtmpStream = RtmpStream;
            newClonedObject.ListenersHidden = ListenersHidden;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.ParticipantsCount = ParticipantsCount;
            newClonedObject.Title = Title;
            newClonedObject.StreamDcId = StreamDcId;
            newClonedObject.RecordStartDate = RecordStartDate;
            newClonedObject.ScheduleDate = ScheduleDate;
            newClonedObject.UnmutedVideoCount = UnmutedVideoCount;
            newClonedObject.UnmutedVideoLimit = UnmutedVideoLimit;
            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (JoinMuted != castedOther.JoinMuted)
            {
                return true;
            }

            if (CanChangeJoinMuted != castedOther.CanChangeJoinMuted)
            {
                return true;
            }

            if (JoinDateAsc != castedOther.JoinDateAsc)
            {
                return true;
            }

            if (ScheduleStartSubscribed != castedOther.ScheduleStartSubscribed)
            {
                return true;
            }

            if (CanStartVideo != castedOther.CanStartVideo)
            {
                return true;
            }

            if (RecordVideoActive != castedOther.RecordVideoActive)
            {
                return true;
            }

            if (RtmpStream != castedOther.RtmpStream)
            {
                return true;
            }

            if (ListenersHidden != castedOther.ListenersHidden)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (ParticipantsCount != castedOther.ParticipantsCount)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (StreamDcId != castedOther.StreamDcId)
            {
                return true;
            }

            if (RecordStartDate != castedOther.RecordStartDate)
            {
                return true;
            }

            if (ScheduleDate != castedOther.ScheduleDate)
            {
                return true;
            }

            if (UnmutedVideoCount != castedOther.UnmutedVideoCount)
            {
                return true;
            }

            if (UnmutedVideoLimit != castedOther.UnmutedVideoLimit)
            {
                return true;
            }

            if (Version != castedOther.Version)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
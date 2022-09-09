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
    public partial class GroupCallParticipant : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Muted = 1 << 0,
            Left = 1 << 1,
            CanSelfUnmute = 1 << 2,
            JustJoined = 1 << 4,
            Versioned = 1 << 5,
            Min = 1 << 8,
            MutedByYou = 1 << 9,
            VolumeByAdmin = 1 << 10,
            Self = 1 << 12,
            VideoJoined = 1 << 15,
            ActiveDate = 1 << 3,
            Volume = 1 << 7,
            About = 1 << 11,
            RaiseHandRating = 1 << 13,
            Video = 1 << 6,
            Presentation = 1 << 14
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -341428482; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("muted")]
        public sealed override bool Muted { get; set; }

        [Newtonsoft.Json.JsonProperty("left")] public sealed override bool Left { get; set; }

        [Newtonsoft.Json.JsonProperty("can_self_unmute")]
        public sealed override bool CanSelfUnmute { get; set; }

        [Newtonsoft.Json.JsonProperty("just_joined")]
        public sealed override bool JustJoined { get; set; }

        [Newtonsoft.Json.JsonProperty("versioned")]
        public sealed override bool Versioned { get; set; }

        [Newtonsoft.Json.JsonProperty("min")] public sealed override bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("muted_by_you")]
        public sealed override bool MutedByYou { get; set; }

        [Newtonsoft.Json.JsonProperty("volume_by_admin")]
        public sealed override bool VolumeByAdmin { get; set; }

        [Newtonsoft.Json.JsonProperty("self")] public sealed override bool Self { get; set; }

        [Newtonsoft.Json.JsonProperty("video_joined")]
        public sealed override bool VideoJoined { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("active_date")]
        public sealed override int? ActiveDate { get; set; }

        [Newtonsoft.Json.JsonProperty("source")]
        public sealed override int Source { get; set; }

        [Newtonsoft.Json.JsonProperty("volume")]
        public sealed override int? Volume { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("raise_hand_rating")]
        public sealed override long? RaiseHandRating { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("video")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Video { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("presentation")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Presentation { get; set; }


#nullable enable
        public GroupCallParticipant(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int date, int source)
        {
            Peer = peer;
            Date = date;
            Source = source;
        }
#nullable disable
        internal GroupCallParticipant()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Muted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Left ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = CanSelfUnmute ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = JustJoined ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Versioned ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Min ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = MutedByYou ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
            Flags = VolumeByAdmin ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = Self ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = VideoJoined ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
            Flags = ActiveDate == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Volume == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = RaiseHandRating == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
            Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = Presentation == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(ActiveDate.Value);
            }

            writer.WriteInt32(Source);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteInt32(Volume.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteString(About);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                writer.WriteInt64(RaiseHandRating.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var checkvideo = writer.WriteObject(Video);
                if (checkvideo.IsError)
                {
                    return checkvideo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var checkpresentation = writer.WriteObject(Presentation);
                if (checkpresentation.IsError)
                {
                    return checkpresentation;
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
            Muted = FlagsHelper.IsFlagSet(Flags, 0);
            Left = FlagsHelper.IsFlagSet(Flags, 1);
            CanSelfUnmute = FlagsHelper.IsFlagSet(Flags, 2);
            JustJoined = FlagsHelper.IsFlagSet(Flags, 4);
            Versioned = FlagsHelper.IsFlagSet(Flags, 5);
            Min = FlagsHelper.IsFlagSet(Flags, 8);
            MutedByYou = FlagsHelper.IsFlagSet(Flags, 9);
            VolumeByAdmin = FlagsHelper.IsFlagSet(Flags, 10);
            Self = FlagsHelper.IsFlagSet(Flags, 12);
            VideoJoined = FlagsHelper.IsFlagSet(Flags, 15);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryactiveDate = reader.ReadInt32();
                if (tryactiveDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryactiveDate);
                }

                ActiveDate = tryactiveDate.Value;
            }

            var trysource = reader.ReadInt32();
            if (trysource.IsError)
            {
                return ReadResult<IObject>.Move(trysource);
            }

            Source = trysource.Value;
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryvolume = reader.ReadInt32();
                if (tryvolume.IsError)
                {
                    return ReadResult<IObject>.Move(tryvolume);
                }

                Volume = tryvolume.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }

                About = tryabout.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var tryraiseHandRating = reader.ReadInt64();
                if (tryraiseHandRating.IsError)
                {
                    return ReadResult<IObject>.Move(tryraiseHandRating);
                }

                RaiseHandRating = tryraiseHandRating.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var tryvideo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase>();
                if (tryvideo.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideo);
                }

                Video = tryvideo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var trypresentation = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase>();
                if (trypresentation.IsError)
                {
                    return ReadResult<IObject>.Move(trypresentation);
                }

                Presentation = trypresentation.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "groupCallParticipant";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallParticipant();
            newClonedObject.Flags = Flags;
            newClonedObject.Muted = Muted;
            newClonedObject.Left = Left;
            newClonedObject.CanSelfUnmute = CanSelfUnmute;
            newClonedObject.JustJoined = JustJoined;
            newClonedObject.Versioned = Versioned;
            newClonedObject.Min = Min;
            newClonedObject.MutedByYou = MutedByYou;
            newClonedObject.VolumeByAdmin = VolumeByAdmin;
            newClonedObject.Self = Self;
            newClonedObject.VideoJoined = VideoJoined;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Date = Date;
            newClonedObject.ActiveDate = ActiveDate;
            newClonedObject.Source = Source;
            newClonedObject.Volume = Volume;
            newClonedObject.About = About;
            newClonedObject.RaiseHandRating = RaiseHandRating;
            if (Video is not null)
            {
                var cloneVideo = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase?)Video.Clone();
                if (cloneVideo is null)
                {
                    return null;
                }

                newClonedObject.Video = cloneVideo;
            }

            if (Presentation is not null)
            {
                var clonePresentation = (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase?)Presentation.Clone();
                if (clonePresentation is null)
                {
                    return null;
                }

                newClonedObject.Presentation = clonePresentation;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallParticipant castedOther)
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

            if (Left != castedOther.Left)
            {
                return true;
            }

            if (CanSelfUnmute != castedOther.CanSelfUnmute)
            {
                return true;
            }

            if (JustJoined != castedOther.JustJoined)
            {
                return true;
            }

            if (Versioned != castedOther.Versioned)
            {
                return true;
            }

            if (Min != castedOther.Min)
            {
                return true;
            }

            if (MutedByYou != castedOther.MutedByYou)
            {
                return true;
            }

            if (VolumeByAdmin != castedOther.VolumeByAdmin)
            {
                return true;
            }

            if (Self != castedOther.Self)
            {
                return true;
            }

            if (VideoJoined != castedOther.VideoJoined)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (ActiveDate != castedOther.ActiveDate)
            {
                return true;
            }

            if (Source != castedOther.Source)
            {
                return true;
            }

            if (Volume != castedOther.Volume)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (RaiseHandRating != castedOther.RaiseHandRating)
            {
                return true;
            }

            if (Video is null && castedOther.Video is not null || Video is not null && castedOther.Video is null)
            {
                return true;
            }

            if (Video is not null && castedOther.Video is not null && Video.Compare(castedOther.Video))
            {
                return true;
            }

            if (Presentation is null && castedOther.Presentation is not null || Presentation is not null && castedOther.Presentation is null)
            {
                return true;
            }

            if (Presentation is not null && castedOther.Presentation is not null && Presentation.Compare(castedOther.Presentation))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
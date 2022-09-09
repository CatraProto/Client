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
    public partial class EditGroupCallParticipant : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Muted = 1 << 0,
            Volume = 1 << 1,
            RaiseHand = 1 << 2,
            VideoStopped = 1 << 3,
            VideoPaused = 1 << 4,
            PresentationPaused = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1524155713; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Participant { get; set; }

        [Newtonsoft.Json.JsonProperty("muted")]
        public bool? Muted { get; set; }

        [Newtonsoft.Json.JsonProperty("volume")]
        public int? Volume { get; set; }

        [Newtonsoft.Json.JsonProperty("raise_hand")]
        public bool? RaiseHand { get; set; }

        [Newtonsoft.Json.JsonProperty("video_stopped")]
        public bool? VideoStopped { get; set; }

        [Newtonsoft.Json.JsonProperty("video_paused")]
        public bool? VideoPaused { get; set; }

        [Newtonsoft.Json.JsonProperty("presentation_paused")]
        public bool? PresentationPaused { get; set; }


#nullable enable
        public EditGroupCallParticipant(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant)
        {
            Call = call;
            Participant = participant;
        }
#nullable disable

        internal EditGroupCallParticipant()
        {
        }

        public void UpdateFlags()
        {
            Flags = Muted == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Volume == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = RaiseHand == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = VideoStopped == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = VideoPaused == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PresentationPaused == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
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

            var checkparticipant = writer.WriteObject(Participant);
            if (checkparticipant.IsError)
            {
                return checkparticipant;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkmuted = writer.WriteBool(Muted.Value);
                if (checkmuted.IsError)
                {
                    return checkmuted;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Volume.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkraiseHand = writer.WriteBool(RaiseHand.Value);
                if (checkraiseHand.IsError)
                {
                    return checkraiseHand;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkvideoStopped = writer.WriteBool(VideoStopped.Value);
                if (checkvideoStopped.IsError)
                {
                    return checkvideoStopped;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkvideoPaused = writer.WriteBool(VideoPaused.Value);
                if (checkvideoPaused.IsError)
                {
                    return checkvideoPaused;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkpresentationPaused = writer.WriteBool(PresentationPaused.Value);
                if (checkpresentationPaused.IsError)
                {
                    return checkpresentationPaused;
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
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            var tryparticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryparticipant.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipant);
            }

            Participant = tryparticipant.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymuted = reader.ReadBool();
                if (trymuted.IsError)
                {
                    return ReadResult<IObject>.Move(trymuted);
                }

                Muted = trymuted.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryvolume = reader.ReadInt32();
                if (tryvolume.IsError)
                {
                    return ReadResult<IObject>.Move(tryvolume);
                }

                Volume = tryvolume.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryraiseHand = reader.ReadBool();
                if (tryraiseHand.IsError)
                {
                    return ReadResult<IObject>.Move(tryraiseHand);
                }

                RaiseHand = tryraiseHand.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryvideoStopped = reader.ReadBool();
                if (tryvideoStopped.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoStopped);
                }

                VideoStopped = tryvideoStopped.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryvideoPaused = reader.ReadBool();
                if (tryvideoPaused.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoPaused);
                }

                VideoPaused = tryvideoPaused.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trypresentationPaused = reader.ReadBool();
                if (trypresentationPaused.IsError)
                {
                    return ReadResult<IObject>.Move(trypresentationPaused);
                }

                PresentationPaused = trypresentationPaused.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.editGroupCallParticipant";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditGroupCallParticipant();
            newClonedObject.Flags = Flags;
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            var cloneParticipant = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Participant.Clone();
            if (cloneParticipant is null)
            {
                return null;
            }

            newClonedObject.Participant = cloneParticipant;
            newClonedObject.Muted = Muted;
            newClonedObject.Volume = Volume;
            newClonedObject.RaiseHand = RaiseHand;
            newClonedObject.VideoStopped = VideoStopped;
            newClonedObject.VideoPaused = VideoPaused;
            newClonedObject.PresentationPaused = PresentationPaused;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditGroupCallParticipant castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (Participant.Compare(castedOther.Participant))
            {
                return true;
            }

            if (Muted != castedOther.Muted)
            {
                return true;
            }

            if (Volume != castedOther.Volume)
            {
                return true;
            }

            if (RaiseHand != castedOther.RaiseHand)
            {
                return true;
            }

            if (VideoStopped != castedOther.VideoStopped)
            {
                return true;
            }

            if (VideoPaused != castedOther.VideoPaused)
            {
                return true;
            }

            if (PresentationPaused != castedOther.PresentationPaused)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
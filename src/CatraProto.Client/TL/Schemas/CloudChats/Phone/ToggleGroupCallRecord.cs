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
    public partial class ToggleGroupCallRecord : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Start = 1 << 0,
            Video = 1 << 2,
            Title = 1 << 1,
            VideoPortrait = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -248985848; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("start")]
        public bool Start { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("video_portrait")]
        public bool? VideoPortrait { get; set; }


#nullable enable
        public ToggleGroupCallRecord(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;
        }
#nullable disable

        internal ToggleGroupCallRecord()
        {
        }

        public void UpdateFlags()
        {
            Flags = Start ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Video ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = VideoPortrait == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
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

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkvideoPortrait = writer.WriteBool(VideoPortrait.Value);
                if (checkvideoPortrait.IsError)
                {
                    return checkvideoPortrait;
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
            Start = FlagsHelper.IsFlagSet(Flags, 0);
            Video = FlagsHelper.IsFlagSet(Flags, 2);
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryvideoPortrait = reader.ReadBool();
                if (tryvideoPortrait.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoPortrait);
                }

                VideoPortrait = tryvideoPortrait.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.toggleGroupCallRecord";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleGroupCallRecord();
            newClonedObject.Flags = Flags;
            newClonedObject.Start = Start;
            newClonedObject.Video = Video;
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.Title = Title;
            newClonedObject.VideoPortrait = VideoPortrait;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleGroupCallRecord castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Start != castedOther.Start)
            {
                return true;
            }

            if (Video != castedOther.Video)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (VideoPortrait != castedOther.VideoPortrait)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
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
    public partial class VideoSize : CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            VideoStartTs = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -567037804; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public sealed override int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public sealed override int H { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public sealed override int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("video_start_ts")]
        public sealed override double? VideoStartTs { get; set; }


#nullable enable
        public VideoSize(string type, int w, int h, int size)
        {
            Type = type;
            W = w;
            H = h;
            Size = size;
        }
#nullable disable
        internal VideoSize()
        {
        }

        public override void UpdateFlags()
        {
            Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Type);
            writer.WriteInt32(W);
            writer.WriteInt32(H);
            writer.WriteInt32(Size);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteDouble(VideoStartTs.Value);
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
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }

            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }

            H = tryh.Value;
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryvideoStartTs = reader.ReadDouble();
                if (tryvideoStartTs.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoStartTs);
                }

                VideoStartTs = tryvideoStartTs.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "videoSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new VideoSize();
            newClonedObject.Flags = Flags;
            newClonedObject.Type = Type;
            newClonedObject.W = W;
            newClonedObject.H = H;
            newClonedObject.Size = Size;
            newClonedObject.VideoStartTs = VideoStartTs;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not VideoSize castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (W != castedOther.W)
            {
                return true;
            }

            if (H != castedOther.H)
            {
                return true;
            }

            if (Size != castedOther.Size)
            {
                return true;
            }

            if (VideoStartTs != castedOther.VideoStartTs)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
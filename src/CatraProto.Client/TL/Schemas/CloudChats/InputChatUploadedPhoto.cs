using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputChatUploadedPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            File = 1 << 0,
            Video = 1 << 1,
            VideoStartTs = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -968723890; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("file")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase File { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("video")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputFileBase Video { get; set; }

        [Newtonsoft.Json.JsonProperty("video_start_ts")]
        public double? VideoStartTs { get; set; }



        public InputChatUploadedPhoto()
        {
        }

        public override void UpdateFlags()
        {
            Flags = File == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkfile = writer.WriteObject(File);
                if (checkfile.IsError)
                {
                    return checkfile;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkvideo = writer.WriteObject(Video);
                if (checkvideo.IsError)
                {
                    return checkvideo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
                if (tryfile.IsError)
                {
                    return ReadResult<IObject>.Move(tryfile);
                }
                File = tryfile.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryvideo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputFileBase>();
                if (tryvideo.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideo);
                }
                Video = tryvideo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
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
            return "inputChatUploadedPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
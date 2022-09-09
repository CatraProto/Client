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
    public partial class AutoDownloadSettings : CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Disabled = 1 << 0,
            VideoPreloadLarge = 1 << 1,
            AudioPreloadNext = 1 << 2,
            PhonecallsLessData = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1896171181; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("disabled")]
        public sealed override bool Disabled { get; set; }

        [Newtonsoft.Json.JsonProperty("video_preload_large")]
        public sealed override bool VideoPreloadLarge { get; set; }

        [Newtonsoft.Json.JsonProperty("audio_preload_next")]
        public sealed override bool AudioPreloadNext { get; set; }

        [Newtonsoft.Json.JsonProperty("phonecalls_less_data")]
        public sealed override bool PhonecallsLessData { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_size_max")]
        public sealed override int PhotoSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("video_size_max")]
        public sealed override long VideoSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("file_size_max")]
        public sealed override long FileSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("video_upload_maxbitrate")]
        public sealed override int VideoUploadMaxbitrate { get; set; }


#nullable enable
        public AutoDownloadSettings(int photoSizeMax, long videoSizeMax, long fileSizeMax, int videoUploadMaxbitrate)
        {
            PhotoSizeMax = photoSizeMax;
            VideoSizeMax = videoSizeMax;
            FileSizeMax = fileSizeMax;
            VideoUploadMaxbitrate = videoUploadMaxbitrate;
        }
#nullable disable
        internal AutoDownloadSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Disabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = VideoPreloadLarge ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = AudioPreloadNext ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = PhonecallsLessData ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(PhotoSizeMax);
            writer.WriteInt64(VideoSizeMax);
            writer.WriteInt64(FileSizeMax);
            writer.WriteInt32(VideoUploadMaxbitrate);

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
            Disabled = FlagsHelper.IsFlagSet(Flags, 0);
            VideoPreloadLarge = FlagsHelper.IsFlagSet(Flags, 1);
            AudioPreloadNext = FlagsHelper.IsFlagSet(Flags, 2);
            PhonecallsLessData = FlagsHelper.IsFlagSet(Flags, 3);
            var tryphotoSizeMax = reader.ReadInt32();
            if (tryphotoSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoSizeMax);
            }

            PhotoSizeMax = tryphotoSizeMax.Value;
            var tryvideoSizeMax = reader.ReadInt64();
            if (tryvideoSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(tryvideoSizeMax);
            }

            VideoSizeMax = tryvideoSizeMax.Value;
            var tryfileSizeMax = reader.ReadInt64();
            if (tryfileSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(tryfileSizeMax);
            }

            FileSizeMax = tryfileSizeMax.Value;
            var tryvideoUploadMaxbitrate = reader.ReadInt32();
            if (tryvideoUploadMaxbitrate.IsError)
            {
                return ReadResult<IObject>.Move(tryvideoUploadMaxbitrate);
            }

            VideoUploadMaxbitrate = tryvideoUploadMaxbitrate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "autoDownloadSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AutoDownloadSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.Disabled = Disabled;
            newClonedObject.VideoPreloadLarge = VideoPreloadLarge;
            newClonedObject.AudioPreloadNext = AudioPreloadNext;
            newClonedObject.PhonecallsLessData = PhonecallsLessData;
            newClonedObject.PhotoSizeMax = PhotoSizeMax;
            newClonedObject.VideoSizeMax = VideoSizeMax;
            newClonedObject.FileSizeMax = FileSizeMax;
            newClonedObject.VideoUploadMaxbitrate = VideoUploadMaxbitrate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AutoDownloadSettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Disabled != castedOther.Disabled)
            {
                return true;
            }

            if (VideoPreloadLarge != castedOther.VideoPreloadLarge)
            {
                return true;
            }

            if (AudioPreloadNext != castedOther.AudioPreloadNext)
            {
                return true;
            }

            if (PhonecallsLessData != castedOther.PhonecallsLessData)
            {
                return true;
            }

            if (PhotoSizeMax != castedOther.PhotoSizeMax)
            {
                return true;
            }

            if (VideoSizeMax != castedOther.VideoSizeMax)
            {
                return true;
            }

            if (FileSizeMax != castedOther.FileSizeMax)
            {
                return true;
            }

            if (VideoUploadMaxbitrate != castedOther.VideoUploadMaxbitrate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
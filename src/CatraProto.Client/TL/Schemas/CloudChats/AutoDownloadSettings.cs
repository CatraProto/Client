/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -532532493; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
        public sealed override int VideoSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("file_size_max")]
        public sealed override int FileSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("video_upload_maxbitrate")]
        public sealed override int VideoUploadMaxbitrate { get; set; }


#nullable enable
        public AutoDownloadSettings(int photoSizeMax, int videoSizeMax, int fileSizeMax, int videoUploadMaxbitrate)
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
            writer.WriteInt32(VideoSizeMax);
            writer.WriteInt32(FileSizeMax);
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
            var tryvideoSizeMax = reader.ReadInt32();
            if (tryvideoSizeMax.IsError)
            {
                return ReadResult<IObject>.Move(tryvideoSizeMax);
            }
            VideoSizeMax = tryvideoSizeMax.Value;
            var tryfileSizeMax = reader.ReadInt32();
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
            var newClonedObject = new AutoDownloadSettings
            {
                Flags = Flags,
                Disabled = Disabled,
                VideoPreloadLarge = VideoPreloadLarge,
                AudioPreloadNext = AudioPreloadNext,
                PhonecallsLessData = PhonecallsLessData,
                PhotoSizeMax = PhotoSizeMax,
                VideoSizeMax = VideoSizeMax,
                FileSizeMax = FileSizeMax,
                VideoUploadMaxbitrate = VideoUploadMaxbitrate
            };
            return newClonedObject;

        }
#nullable disable
    }
}
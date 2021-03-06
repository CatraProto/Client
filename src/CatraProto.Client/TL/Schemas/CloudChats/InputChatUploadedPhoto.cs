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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputChatUploadedPhoto
            {
                Flags = Flags
            };
            if (File is not null)
            {
                var cloneFile = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)File.Clone();
                if (cloneFile is null)
                {
                    return null;
                }
                newClonedObject.File = cloneFile;
            }
            if (Video is not null)
            {
                var cloneVideo = (CatraProto.Client.TL.Schemas.CloudChats.InputFileBase?)Video.Clone();
                if (cloneVideo is null)
                {
                    return null;
                }
                newClonedObject.Video = cloneVideo;
            }
            newClonedObject.VideoStartTs = VideoStartTs;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputChatUploadedPhoto castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (File is null && castedOther.File is not null || File is not null && castedOther.File is null)
            {
                return true;
            }
            if (File is not null && castedOther.File is not null && File.Compare(castedOther.File))
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
            if (VideoStartTs != castedOther.VideoStartTs)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
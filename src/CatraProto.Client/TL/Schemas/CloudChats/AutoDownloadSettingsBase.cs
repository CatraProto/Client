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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AutoDownloadSettingsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("disabled")]
        public abstract bool Disabled { get; set; }

        [Newtonsoft.Json.JsonProperty("video_preload_large")]
        public abstract bool VideoPreloadLarge { get; set; }

        [Newtonsoft.Json.JsonProperty("audio_preload_next")]
        public abstract bool AudioPreloadNext { get; set; }

        [Newtonsoft.Json.JsonProperty("phonecalls_less_data")]
        public abstract bool PhonecallsLessData { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_size_max")]
        public abstract int PhotoSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("video_size_max")]
        public abstract long VideoSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("file_size_max")]
        public abstract long FileSizeMax { get; set; }

        [Newtonsoft.Json.JsonProperty("video_upload_maxbitrate")]
        public abstract int VideoUploadMaxbitrate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}

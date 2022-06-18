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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Photo : CatraProto.Client.TL.Schemas.CloudChats.PhotoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasStickers = 1 << 0,
            VideoSizes = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -82216347; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_stickers")]
        public bool HasStickers { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("sizes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Sizes { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("video_sizes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoSizes { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }


#nullable enable
        public Photo(long id, long accessHash, byte[] fileReference, int date, List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> sizes, int dcId)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
            Date = date;
            Sizes = sizes;
            DcId = dcId;

        }
#nullable disable
        internal Photo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HasStickers ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = VideoSizes == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteBytes(FileReference);
            writer.WriteInt32(Date);
            var checksizes = writer.WriteVector(Sizes, false);
            if (checksizes.IsError)
            {
                return checksizes;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkvideoSizes = writer.WriteVector(VideoSizes, false);
                if (checkvideoSizes.IsError)
                {
                    return checkvideoSizes;
                }
            }

            writer.WriteInt32(DcId);

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
            HasStickers = FlagsHelper.IsFlagSet(Flags, 0);
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
            var tryfileReference = reader.ReadBytes();
            if (tryfileReference.IsError)
            {
                return ReadResult<IObject>.Move(tryfileReference);
            }
            FileReference = tryfileReference.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var trysizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trysizes.IsError)
            {
                return ReadResult<IObject>.Move(trysizes);
            }
            Sizes = trysizes.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryvideoSizes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryvideoSizes.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoSizes);
                }
                VideoSizes = tryvideoSizes.Value;
            }

            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }
            DcId = trydcId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "photo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Photo
            {
                Flags = Flags,
                HasStickers = HasStickers,
                Id = Id,
                AccessHash = AccessHash,
                FileReference = FileReference,
                Date = Date,
                Sizes = new List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>()
            };
            foreach (var sizes in Sizes)
            {
                var clonesizes = (CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase?)sizes.Clone();
                if (clonesizes is null)
                {
                    return null;
                }
                newClonedObject.Sizes.Add(clonesizes);
            }
            if (VideoSizes is not null)
            {
                newClonedObject.VideoSizes = new List<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
                foreach (var videoSizes in VideoSizes)
                {
                    var clonevideoSizes = (CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase?)videoSizes.Clone();
                    if (clonevideoSizes is null)
                    {
                        return null;
                    }
                    newClonedObject.VideoSizes.Add(clonevideoSizes);
                }
            }
            newClonedObject.DcId = DcId;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Photo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (HasStickers != castedOther.HasStickers)
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
            if (FileReference != castedOther.FileReference)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            var sizessize = castedOther.Sizes.Count;
            if (sizessize != Sizes.Count)
            {
                return true;
            }
            for (var i = 0; i < sizessize; i++)
            {
                if (castedOther.Sizes[i].Compare(Sizes[i]))
                {
                    return true;
                }
            }
            if (VideoSizes is null && castedOther.VideoSizes is not null || VideoSizes is not null && castedOther.VideoSizes is null)
            {
                return true;
            }
            if (VideoSizes is not null && castedOther.VideoSizes is not null)
            {

                var videoSizessize = castedOther.VideoSizes.Count;
                if (videoSizessize != VideoSizes.Count)
                {
                    return true;
                }
                for (var i = 0; i < videoSizessize; i++)
                {
                    if (castedOther.VideoSizes[i].Compare(VideoSizes[i]))
                    {
                        return true;
                    }
                }
            }
            if (DcId != castedOther.DcId)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
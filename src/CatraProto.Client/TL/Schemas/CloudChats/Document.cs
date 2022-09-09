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
    public partial class Document : CatraProto.Client.TL.Schemas.CloudChats.DocumentBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Thumbs = 1 << 0,
            VideoThumbs = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1881881384; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public long Size { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumbs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("video_thumbs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoThumbs { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("attributes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


#nullable enable
        public Document(long id, long accessHash, byte[] fileReference, int date, string mimeType, long size, int dcId, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
            Date = date;
            MimeType = mimeType;
            Size = size;
            DcId = dcId;
            Attributes = attributes;
        }
#nullable disable
        internal Document()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = VideoThumbs == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
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

            writer.WriteString(MimeType);
            writer.WriteInt64(Size);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkthumbs = writer.WriteVector(Thumbs, false);
                if (checkthumbs.IsError)
                {
                    return checkthumbs;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkvideoThumbs = writer.WriteVector(VideoThumbs, false);
                if (checkvideoThumbs.IsError)
                {
                    return checkvideoThumbs;
                }
            }

            writer.WriteInt32(DcId);
            var checkattributes = writer.WriteVector(Attributes, false);
            if (checkattributes.IsError)
            {
                return checkattributes;
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
            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }

            MimeType = trymimeType.Value;
            var trysize = reader.ReadInt64();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trythumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trythumbs.IsError)
                {
                    return ReadResult<IObject>.Move(trythumbs);
                }

                Thumbs = trythumbs.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryvideoThumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryvideoThumbs.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoThumbs);
                }

                VideoThumbs = tryvideoThumbs.Value;
            }

            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryattributes.IsError)
            {
                return ReadResult<IObject>.Move(tryattributes);
            }

            Attributes = tryattributes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "document";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Document();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.FileReference = FileReference;
            newClonedObject.Date = Date;
            newClonedObject.MimeType = MimeType;
            newClonedObject.Size = Size;
            if (Thumbs is not null)
            {
                newClonedObject.Thumbs = new List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
                foreach (var thumbs in Thumbs)
                {
                    var clonethumbs = (CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase?)thumbs.Clone();
                    if (clonethumbs is null)
                    {
                        return null;
                    }

                    newClonedObject.Thumbs.Add(clonethumbs);
                }
            }

            if (VideoThumbs is not null)
            {
                newClonedObject.VideoThumbs = new List<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>();
                foreach (var videoThumbs in VideoThumbs)
                {
                    var clonevideoThumbs = (CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase?)videoThumbs.Clone();
                    if (clonevideoThumbs is null)
                    {
                        return null;
                    }

                    newClonedObject.VideoThumbs.Add(clonevideoThumbs);
                }
            }

            newClonedObject.DcId = DcId;
            newClonedObject.Attributes = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();
            foreach (var attributes in Attributes)
            {
                var cloneattributes = (CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase?)attributes.Clone();
                if (cloneattributes is null)
                {
                    return null;
                }

                newClonedObject.Attributes.Add(cloneattributes);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Document castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
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

            if (MimeType != castedOther.MimeType)
            {
                return true;
            }

            if (Size != castedOther.Size)
            {
                return true;
            }

            if (Thumbs is null && castedOther.Thumbs is not null || Thumbs is not null && castedOther.Thumbs is null)
            {
                return true;
            }

            if (Thumbs is not null && castedOther.Thumbs is not null)
            {
                var thumbssize = castedOther.Thumbs.Count;
                if (thumbssize != Thumbs.Count)
                {
                    return true;
                }

                for (var i = 0; i < thumbssize; i++)
                {
                    if (castedOther.Thumbs[i].Compare(Thumbs[i]))
                    {
                        return true;
                    }
                }
            }

            if (VideoThumbs is null && castedOther.VideoThumbs is not null || VideoThumbs is not null && castedOther.VideoThumbs is null)
            {
                return true;
            }

            if (VideoThumbs is not null && castedOther.VideoThumbs is not null)
            {
                var videoThumbssize = castedOther.VideoThumbs.Count;
                if (videoThumbssize != VideoThumbs.Count)
                {
                    return true;
                }

                for (var i = 0; i < videoThumbssize; i++)
                {
                    if (castedOther.VideoThumbs[i].Compare(VideoThumbs[i]))
                    {
                        return true;
                    }
                }
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            var attributessize = castedOther.Attributes.Count;
            if (attributessize != Attributes.Count)
            {
                return true;
            }

            for (var i = 0; i < attributessize; i++)
            {
                if (castedOther.Attributes[i].Compare(Attributes[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
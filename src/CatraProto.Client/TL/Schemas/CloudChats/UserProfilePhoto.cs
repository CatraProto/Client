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
    public partial class UserProfilePhoto : CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasVideo = 1 << 0,
            StrippedThumb = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2100168954; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_video")]
        public bool HasVideo { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public long PhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("stripped_thumb")]
        public byte[] StrippedThumb { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }


#nullable enable
        public UserProfilePhoto(long photoId, int dcId)
        {
            PhotoId = photoId;
            DcId = dcId;
        }
#nullable disable
        internal UserProfilePhoto()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HasVideo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = StrippedThumb == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(PhotoId);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteBytes(StrippedThumb);
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
            HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
            var tryphotoId = reader.ReadInt64();
            if (tryphotoId.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoId);
            }

            PhotoId = tryphotoId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trystrippedThumb = reader.ReadBytes();
                if (trystrippedThumb.IsError)
                {
                    return ReadResult<IObject>.Move(trystrippedThumb);
                }

                StrippedThumb = trystrippedThumb.Value;
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
            return "userProfilePhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserProfilePhoto();
            newClonedObject.Flags = Flags;
            newClonedObject.HasVideo = HasVideo;
            newClonedObject.PhotoId = PhotoId;
            newClonedObject.StrippedThumb = StrippedThumb;
            newClonedObject.DcId = DcId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UserProfilePhoto castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (HasVideo != castedOther.HasVideo)
            {
                return true;
            }

            if (PhotoId != castedOther.PhotoId)
            {
                return true;
            }

            if (StrippedThumb != castedOther.StrippedThumb)
            {
                return true;
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
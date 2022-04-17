using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatPhoto : CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasVideo = 1 << 0,
            StrippedThumb = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 476978193; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_video")]
        public bool HasVideo { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public long PhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("stripped_thumb")]
        public byte[] StrippedThumb { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }


#nullable enable
        public ChatPhoto(long photoId, int dcId)
        {
            PhotoId = photoId;
            DcId = dcId;

        }
#nullable disable
        internal ChatPhoto()
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
            return "chatPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
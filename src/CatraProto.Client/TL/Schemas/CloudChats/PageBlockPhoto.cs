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
    public partial class PageBlockPhoto : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Url = 1 << 0,
            WebpageId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 391759200; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public long PhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage_id")]
        public long? WebpageId { get; set; }


#nullable enable
        public PageBlockPhoto(long photoId, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            PhotoId = photoId;
            Caption = caption;
        }
#nullable disable
        internal PageBlockPhoto()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = WebpageId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(PhotoId);
            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Url);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(WebpageId.Value);
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
            var tryphotoId = reader.ReadInt64();
            if (tryphotoId.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoId);
            }

            PhotoId = tryphotoId.Value;
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }

            Caption = trycaption.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }

                Url = tryurl.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trywebpageId = reader.ReadInt64();
                if (trywebpageId.IsError)
                {
                    return ReadResult<IObject>.Move(trywebpageId);
                }

                WebpageId = trywebpageId.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockPhoto();
            newClonedObject.Flags = Flags;
            newClonedObject.PhotoId = PhotoId;
            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }

            newClonedObject.Caption = cloneCaption;
            newClonedObject.Url = Url;
            newClonedObject.WebpageId = WebpageId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockPhoto castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (PhotoId != castedOther.PhotoId)
            {
                return true;
            }

            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (WebpageId != castedOther.WebpageId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
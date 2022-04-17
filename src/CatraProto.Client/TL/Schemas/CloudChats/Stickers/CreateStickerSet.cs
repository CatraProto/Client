using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class CreateStickerSet : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0,
            Animated = 1 << 1,
            Videos = 1 << 4,
            Thumb = 1 << 2,
            Software = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1876841625; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("animated")]
        public bool Animated { get; set; }

        [Newtonsoft.Json.JsonProperty("videos")]
        public bool Videos { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Thumb { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> Stickers { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("software")]
        public string Software { get; set; }


#nullable enable
        public CreateStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string title, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers)
        {
            UserId = userId;
            Title = title;
            ShortName = shortName;
            Stickers = stickers;

        }
#nullable disable

        internal CreateStickerSet()
        {
        }

        public void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Animated ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Videos ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Software == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteString(Title);

            writer.WriteString(ShortName);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkthumb = writer.WriteObject(Thumb);
                if (checkthumb.IsError)
                {
                    return checkthumb;
                }
            }

            var checkstickers = writer.WriteVector(Stickers, false);
            if (checkstickers.IsError)
            {
                return checkstickers;
            }
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {

                writer.WriteString(Software);
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            Animated = FlagsHelper.IsFlagSet(Flags, 1);
            Videos = FlagsHelper.IsFlagSet(Flags, 4);
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
                if (trythumb.IsError)
                {
                    return ReadResult<IObject>.Move(trythumb);
                }
                Thumb = trythumb.Value;
            }

            var trystickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickers.IsError)
            {
                return ReadResult<IObject>.Move(trystickers);
            }
            Stickers = trystickers.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trysoftware = reader.ReadString();
                if (trysoftware.IsError)
                {
                    return ReadResult<IObject>.Move(trysoftware);
                }
                Software = trysoftware.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.createStickerSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
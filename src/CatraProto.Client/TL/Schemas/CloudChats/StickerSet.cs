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
    public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Archived = 1 << 1,
            Official = 1 << 2,
            Masks = 1 << 3,
            Animated = 1 << 5,
            Videos = 1 << 6,
            InstalledDate = 1 << 0,
            Thumbs = 1 << 4,
            ThumbDcId = 1 << 4,
            ThumbVersion = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -673242758; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("archived")]
        public sealed override bool Archived { get; set; }

        [Newtonsoft.Json.JsonProperty("official")]
        public sealed override bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public sealed override bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("animated")]
        public sealed override bool Animated { get; set; }

        [Newtonsoft.Json.JsonProperty("videos")]
        public sealed override bool Videos { get; set; }

        [Newtonsoft.Json.JsonProperty("installed_date")]
        public sealed override int? InstalledDate { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public sealed override string ShortName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumbs")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_dc_id")]
        public sealed override int? ThumbDcId { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_version")]
        public sealed override int? ThumbVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override int Hash { get; set; }


#nullable enable
        public StickerSet(long id, long accessHash, string title, string shortName, int count, int hash)
        {
            Id = id;
            AccessHash = accessHash;
            Title = title;
            ShortName = shortName;
            Count = count;
            Hash = hash;
        }
#nullable disable
        internal StickerSet()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Archived ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Official ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Animated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Videos ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = InstalledDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = ThumbDcId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = ThumbVersion == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(InstalledDate.Value);
            }

            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteString(Title);

            writer.WriteString(ShortName);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkthumbs = writer.WriteVector(Thumbs, false);
                if (checkthumbs.IsError)
                {
                    return checkthumbs;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(ThumbDcId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(ThumbVersion.Value);
            }

            writer.WriteInt32(Count);
            writer.WriteInt32(Hash);

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
            Archived = FlagsHelper.IsFlagSet(Flags, 1);
            Official = FlagsHelper.IsFlagSet(Flags, 2);
            Masks = FlagsHelper.IsFlagSet(Flags, 3);
            Animated = FlagsHelper.IsFlagSet(Flags, 5);
            Videos = FlagsHelper.IsFlagSet(Flags, 6);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryinstalledDate = reader.ReadInt32();
                if (tryinstalledDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryinstalledDate);
                }

                InstalledDate = tryinstalledDate.Value;
            }

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
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trythumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trythumbs.IsError)
                {
                    return ReadResult<IObject>.Move(trythumbs);
                }

                Thumbs = trythumbs.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trythumbDcId = reader.ReadInt32();
                if (trythumbDcId.IsError)
                {
                    return ReadResult<IObject>.Move(trythumbDcId);
                }

                ThumbDcId = trythumbDcId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trythumbVersion = reader.ReadInt32();
                if (trythumbVersion.IsError)
                {
                    return ReadResult<IObject>.Move(trythumbVersion);
                }

                ThumbVersion = trythumbVersion.Value;
            }

            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var tryhash = reader.ReadInt32();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSet();
            newClonedObject.Flags = Flags;
            newClonedObject.Archived = Archived;
            newClonedObject.Official = Official;
            newClonedObject.Masks = Masks;
            newClonedObject.Animated = Animated;
            newClonedObject.Videos = Videos;
            newClonedObject.InstalledDate = InstalledDate;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Title = Title;
            newClonedObject.ShortName = ShortName;
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

            newClonedObject.ThumbDcId = ThumbDcId;
            newClonedObject.ThumbVersion = ThumbVersion;
            newClonedObject.Count = Count;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StickerSet castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Archived != castedOther.Archived)
            {
                return true;
            }

            if (Official != castedOther.Official)
            {
                return true;
            }

            if (Masks != castedOther.Masks)
            {
                return true;
            }

            if (Animated != castedOther.Animated)
            {
                return true;
            }

            if (Videos != castedOther.Videos)
            {
                return true;
            }

            if (InstalledDate != castedOther.InstalledDate)
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

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (ShortName != castedOther.ShortName)
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

            if (ThumbDcId != castedOther.ThumbDcId)
            {
                return true;
            }

            if (ThumbVersion != castedOther.ThumbVersion)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
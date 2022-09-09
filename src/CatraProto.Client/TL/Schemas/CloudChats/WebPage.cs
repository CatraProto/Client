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
    public partial class WebPage : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Type = 1 << 0,
            SiteName = 1 << 1,
            Title = 1 << 2,
            Description = 1 << 3,
            Photo = 1 << 4,
            EmbedUrl = 1 << 5,
            EmbedType = 1 << 5,
            EmbedWidth = 1 << 6,
            EmbedHeight = 1 << 6,
            Duration = 1 << 7,
            Author = 1 << 8,
            Document = 1 << 9,
            CachedPage = 1 << 10,
            Attributes = 1 << 12
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -392411726; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public int Hash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("site_name")]
        public string SiteName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("embed_type")]
        public string EmbedType { get; set; }

        [Newtonsoft.Json.JsonProperty("embed_width")]
        public int? EmbedWidth { get; set; }

        [Newtonsoft.Json.JsonProperty("embed_height")]
        public int? EmbedHeight { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("author")]
        public string Author { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("cached_page")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageBase CachedPage { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("attributes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase> Attributes { get; set; }


#nullable enable
        public WebPage(long id, string url, string displayUrl, int hash)
        {
            Id = id;
            Url = url;
            DisplayUrl = displayUrl;
            Hash = hash;
        }
#nullable disable
        internal WebPage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Type == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SiteName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = EmbedUrl == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = EmbedType == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = EmbedWidth == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = EmbedHeight == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = Author == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = CachedPage == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = Attributes == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);

            writer.WriteString(Url);

            writer.WriteString(DisplayUrl);
            writer.WriteInt32(Hash);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Type);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(SiteName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteString(EmbedUrl);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteString(EmbedType);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(EmbedWidth.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(EmbedHeight.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteInt32(Duration.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.WriteString(Author);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var checkcachedPage = writer.WriteObject(CachedPage);
                if (checkcachedPage.IsError)
                {
                    return checkcachedPage;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var checkattributes = writer.WriteVector(Attributes, false);
                if (checkattributes.IsError)
                {
                    return checkattributes;
                }
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
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trydisplayUrl = reader.ReadString();
            if (trydisplayUrl.IsError)
            {
                return ReadResult<IObject>.Move(trydisplayUrl);
            }

            DisplayUrl = trydisplayUrl.Value;
            var tryhash = reader.ReadInt32();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytype = reader.ReadString();
                if (trytype.IsError)
                {
                    return ReadResult<IObject>.Move(trytype);
                }

                Type = trytype.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysiteName = reader.ReadString();
                if (trysiteName.IsError)
                {
                    return ReadResult<IObject>.Move(trysiteName);
                }

                SiteName = trysiteName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }

                Description = trydescription.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryembedUrl = reader.ReadString();
                if (tryembedUrl.IsError)
                {
                    return ReadResult<IObject>.Move(tryembedUrl);
                }

                EmbedUrl = tryembedUrl.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryembedType = reader.ReadString();
                if (tryembedType.IsError)
                {
                    return ReadResult<IObject>.Move(tryembedType);
                }

                EmbedType = tryembedType.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var tryembedWidth = reader.ReadInt32();
                if (tryembedWidth.IsError)
                {
                    return ReadResult<IObject>.Move(tryembedWidth);
                }

                EmbedWidth = tryembedWidth.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var tryembedHeight = reader.ReadInt32();
                if (tryembedHeight.IsError)
                {
                    return ReadResult<IObject>.Move(tryembedHeight);
                }

                EmbedHeight = tryembedHeight.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryduration = reader.ReadInt32();
                if (tryduration.IsError)
                {
                    return ReadResult<IObject>.Move(tryduration);
                }

                Duration = tryduration.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var tryauthor = reader.ReadString();
                if (tryauthor.IsError)
                {
                    return ReadResult<IObject>.Move(tryauthor);
                }

                Author = tryauthor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }

                Document = trydocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                var trycachedPage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageBase>();
                if (trycachedPage.IsError)
                {
                    return ReadResult<IObject>.Move(trycachedPage);
                }

                CachedPage = trycachedPage.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryattributes.IsError)
                {
                    return ReadResult<IObject>.Move(tryattributes);
                }

                Attributes = tryattributes.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "webPage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebPage();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
            newClonedObject.Url = Url;
            newClonedObject.DisplayUrl = DisplayUrl;
            newClonedObject.Hash = Hash;
            newClonedObject.Type = Type;
            newClonedObject.SiteName = SiteName;
            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }

                newClonedObject.Photo = clonePhoto;
            }

            newClonedObject.EmbedUrl = EmbedUrl;
            newClonedObject.EmbedType = EmbedType;
            newClonedObject.EmbedWidth = EmbedWidth;
            newClonedObject.EmbedHeight = EmbedHeight;
            newClonedObject.Duration = Duration;
            newClonedObject.Author = Author;
            if (Document is not null)
            {
                var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
                if (cloneDocument is null)
                {
                    return null;
                }

                newClonedObject.Document = cloneDocument;
            }

            if (CachedPage is not null)
            {
                var cloneCachedPage = (CatraProto.Client.TL.Schemas.CloudChats.PageBase?)CachedPage.Clone();
                if (cloneCachedPage is null)
                {
                    return null;
                }

                newClonedObject.CachedPage = cloneCachedPage;
            }

            if (Attributes is not null)
            {
                newClonedObject.Attributes = new List<CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase>();
                foreach (var attributes in Attributes)
                {
                    var cloneattributes = (CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase?)attributes.Clone();
                    if (cloneattributes is null)
                    {
                        return null;
                    }

                    newClonedObject.Attributes.Add(cloneattributes);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebPage castedOther)
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

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (DisplayUrl != castedOther.DisplayUrl)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (SiteName != castedOther.SiteName)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (Photo is null && castedOther.Photo is not null || Photo is not null && castedOther.Photo is null)
            {
                return true;
            }

            if (Photo is not null && castedOther.Photo is not null && Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (EmbedUrl != castedOther.EmbedUrl)
            {
                return true;
            }

            if (EmbedType != castedOther.EmbedType)
            {
                return true;
            }

            if (EmbedWidth != castedOther.EmbedWidth)
            {
                return true;
            }

            if (EmbedHeight != castedOther.EmbedHeight)
            {
                return true;
            }

            if (Duration != castedOther.Duration)
            {
                return true;
            }

            if (Author != castedOther.Author)
            {
                return true;
            }

            if (Document is null && castedOther.Document is not null || Document is not null && castedOther.Document is null)
            {
                return true;
            }

            if (Document is not null && castedOther.Document is not null && Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (CachedPage is null && castedOther.CachedPage is not null || CachedPage is not null && castedOther.CachedPage is null)
            {
                return true;
            }

            if (CachedPage is not null && castedOther.CachedPage is not null && CachedPage.Compare(castedOther.CachedPage))
            {
                return true;
            }

            if (Attributes is null && castedOther.Attributes is not null || Attributes is not null && castedOther.Attributes is null)
            {
                return true;
            }

            if (Attributes is not null && castedOther.Attributes is not null)
            {
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
            }

            return false;
        }

#nullable disable
    }
}
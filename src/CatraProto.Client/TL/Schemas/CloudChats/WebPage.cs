using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebPage : WebPageBase
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

        public static int ConstructorId { get; } = -392411726;
        public int Flags { get; set; }
        public long Id { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public int Hash { get; set; }
        public string Type { get; set; }
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PhotoBase Photo { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedType { get; set; }
        public int? EmbedWidth { get; set; }
        public int? EmbedHeight { get; set; }
        public int? Duration { get; set; }
        public string Author { get; set; }
        public DocumentBase Document { get; set; }
        public PageBase CachedPage { get; set; }
        public IList<WebPageAttributeBase> Attributes { get; set; }

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

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Url);
            writer.Write(DisplayUrl);
            writer.Write(Hash);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Type);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(SiteName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(Photo);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(EmbedUrl);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(EmbedType);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.Write(EmbedWidth.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.Write(EmbedHeight.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.Write(Duration.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.Write(Author);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.Write(Document);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.Write(CachedPage);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                writer.Write(Attributes);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<long>();
            Url = reader.Read<string>();
            DisplayUrl = reader.Read<string>();
            Hash = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Type = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                SiteName = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Title = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Description = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                Photo = reader.Read<PhotoBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                EmbedUrl = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                EmbedType = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                EmbedWidth = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                EmbedHeight = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                Duration = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                Author = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                Document = reader.Read<DocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                CachedPage = reader.Read<PageBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                Attributes = reader.ReadVector<WebPageAttributeBase>();
            }
        }
    }
}
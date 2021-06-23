using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PageRelatedArticle : PageRelatedArticleBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 0,
            Description = 1 << 1,
            PhotoId = 1 << 2,
            Author = 1 << 3,
            PublishedDate = 1 << 4
        }

        public static int ConstructorId { get; } = -1282352120;
        public int Flags { get; set; }
        public override string Url { get; set; }
        public override long WebpageId { get; set; }
        public override string Title { get; set; }
        public override string Description { get; set; }
        public override long? PhotoId { get; set; }
        public override string Author { get; set; }
        public override int? PublishedDate { get; set; }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = PhotoId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Author == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = PublishedDate == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Url);
            writer.Write(WebpageId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Description);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(PhotoId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Author);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(PublishedDate.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Url = reader.Read<string>();
            WebpageId = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Title = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Description = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                PhotoId = reader.Read<long>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Author = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                PublishedDate = reader.Read<int>();
            }
        }
    }
}
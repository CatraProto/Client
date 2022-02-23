using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputThemeSlug : CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase
    {
        public static int StaticConstructorId
        {
            get => -175567375;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("slug")] public string Slug { get; set; }


    #nullable enable
        public InputThemeSlug(string slug)
        {
            Slug = slug;
        }
    #nullable disable
        internal InputThemeSlug()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Slug);
        }

        public override void Deserialize(Reader reader)
        {
            Slug = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputThemeSlug";
        }
    }
}
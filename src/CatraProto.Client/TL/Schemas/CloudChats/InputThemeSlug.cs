using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputThemeSlug : CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -175567375; }

        [Newtonsoft.Json.JsonProperty("slug")]
        public string Slug { get; set; }


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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Slug);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryslug = reader.ReadString();
            if (tryslug.IsError)
            {
                return ReadResult<IObject>.Move(tryslug);
            }
            Slug = tryslug.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputThemeSlug";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputThemeSlug
            {
                Slug = Slug
            };
            return newClonedObject;

        }
#nullable disable
    }
}
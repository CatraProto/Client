using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateTheme : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2112423005; }

        [Newtonsoft.Json.JsonProperty("theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.ThemeBase Theme { get; set; }


#nullable enable
        public UpdateTheme(CatraProto.Client.TL.Schemas.CloudChats.ThemeBase theme)
        {
            Theme = theme;

        }
#nullable disable
        internal UpdateTheme()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktheme = writer.WriteObject(Theme);
            if (checktheme.IsError)
            {
                return checktheme;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
            if (trytheme.IsError)
            {
                return ReadResult<IObject>.Move(trytheme);
            }
            Theme = trytheme.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateTheme";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ThemesNotModified : ThemesBase
    {
        public static int StaticConstructorId
        {
            get => -199313886;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "account.themesNotModified";
        }
    }
}
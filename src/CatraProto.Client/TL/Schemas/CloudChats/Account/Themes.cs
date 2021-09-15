using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class Themes : ThemesBase
    {
        public static int StaticConstructorId
        {
            get => 2137482273;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("themes")] public IList<ThemeBase> ThemesField { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
            writer.Write(ThemesField);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            ThemesField = reader.ReadVector<ThemeBase>();
        }

        public override string ToString()
        {
            return "account.themes";
        }
    }
}
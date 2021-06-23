using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class PassportConfig : PassportConfigBase
    {
        public static int ConstructorId { get; } = -1600596305;
        public int Hash { get; set; }
        public DataJSONBase CountriesLangs { get; set; }

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
            writer.Write(CountriesLangs);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            CountriesLangs = reader.Read<DataJSONBase>();
        }
    }
}
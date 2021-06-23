using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class GetCountriesList : IMethod
    {
        public static int ConstructorId { get; } = 1935116200;

        public System.Type Type { get; init; } = typeof(CountriesListBase);
        public bool IsVector { get; init; } = false;
        public string LangCode { get; set; }
        public int Hash { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(LangCode);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
            Hash = reader.Read<int>();
        }
    }
}
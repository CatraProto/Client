using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfServiceUpdateEmpty : TermsOfServiceUpdateBase
    {
        public static int StaticConstructorId
        {
            get => -483352705;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("expires")] public override int Expires { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Expires);
        }

        public override void Deserialize(Reader reader)
        {
            Expires = reader.Read<int>();
        }

        public override string ToString()
        {
            return "help.termsOfServiceUpdateEmpty";
        }
    }
}
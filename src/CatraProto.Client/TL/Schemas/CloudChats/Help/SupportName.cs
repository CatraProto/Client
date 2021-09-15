using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SupportName : SupportNameBase
    {
        public static int StaticConstructorId
        {
            get => -1945767479;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("name")] public override string Name { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Name);
        }

        public override void Deserialize(Reader reader)
        {
            Name = reader.Read<string>();
        }

        public override string ToString()
        {
            return "help.supportName";
        }
    }
}
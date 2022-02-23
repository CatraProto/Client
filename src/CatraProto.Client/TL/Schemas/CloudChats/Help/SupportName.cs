using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SupportName : CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase
    {
        public static int StaticConstructorId
        {
            get => -1945767479;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


    #nullable enable
        public SupportName(string name)
        {
            Name = name;
        }
    #nullable disable
        internal SupportName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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
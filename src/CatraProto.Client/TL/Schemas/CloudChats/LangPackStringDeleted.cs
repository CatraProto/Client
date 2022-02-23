using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LangPackStringDeleted : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
    {
        public static int StaticConstructorId
        {
            get => 695856818;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }


    #nullable enable
        public LangPackStringDeleted(string key)
        {
            Key = key;
        }
    #nullable disable
        internal LangPackStringDeleted()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Key);
        }

        public override void Deserialize(Reader reader)
        {
            Key = reader.Read<string>();
        }

        public override string ToString()
        {
            return "langPackStringDeleted";
        }
    }
}
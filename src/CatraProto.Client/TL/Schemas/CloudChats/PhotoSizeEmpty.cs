using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhotoSizeEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        public static int StaticConstructorId
        {
            get => 236446268;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }


    #nullable enable
        public PhotoSizeEmpty(string type)
        {
            Type = type;
        }
    #nullable disable
        internal PhotoSizeEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Type);
        }

        public override void Deserialize(Reader reader)
        {
            Type = reader.Read<string>();
        }

        public override string ToString()
        {
            return "photoSizeEmpty";
        }
    }
}
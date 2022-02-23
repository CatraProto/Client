using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickeredMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase
    {
        public static int StaticConstructorId
        {
            get => 1251549527;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }


    #nullable enable
        public InputStickeredMediaPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
        {
            Id = id;
        }
    #nullable disable
        internal InputStickeredMediaPhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
        }

        public override string ToString()
        {
            return "inputStickeredMediaPhoto";
        }
    }
}
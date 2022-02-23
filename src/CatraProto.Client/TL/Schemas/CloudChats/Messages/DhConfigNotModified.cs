using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DhConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase
    {
        public static int StaticConstructorId
        {
            get => -1058912715;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("random")]
        public sealed override byte[] Random { get; set; }


    #nullable enable
        public DhConfigNotModified(byte[] random)
        {
            Random = random;
        }
    #nullable disable
        internal DhConfigNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Random);
        }

        public override void Deserialize(Reader reader)
        {
            Random = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "messages.dhConfigNotModified";
        }
    }
}
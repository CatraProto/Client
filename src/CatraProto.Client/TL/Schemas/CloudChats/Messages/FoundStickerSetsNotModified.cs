using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FoundStickerSetsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase
    {
        public static int StaticConstructorId
        {
            get => 223655517;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public FoundStickerSetsNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "messages.foundStickerSetsNotModified";
        }
    }
}
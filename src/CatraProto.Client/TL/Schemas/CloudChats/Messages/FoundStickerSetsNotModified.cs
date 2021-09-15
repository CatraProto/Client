using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FoundStickerSetsNotModified : FoundStickerSetsBase
    {
        public static int StaticConstructorId
        {
            get => 223655517;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }
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
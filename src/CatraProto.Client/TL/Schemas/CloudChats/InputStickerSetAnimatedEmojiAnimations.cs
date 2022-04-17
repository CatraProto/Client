using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickerSetAnimatedEmojiAnimations : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 215889721; }



        public InputStickerSetAnimatedEmojiAnimations()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputStickerSetAnimatedEmojiAnimations";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
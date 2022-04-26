using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StickerSetNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -738646805; }



        public StickerSetNotModified()
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
            return "messages.stickerSetNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSetNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}
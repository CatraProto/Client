using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterPhotos : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1777752804; }



        public InputMessagesFilterPhotos()
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
            return "inputMessagesFilterPhotos";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessagesFilterPhotos();
            return newClonedObject;

        }
#nullable disable
    }
}
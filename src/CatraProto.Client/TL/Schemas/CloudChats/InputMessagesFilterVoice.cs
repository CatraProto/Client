using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterVoice : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1358283666; }



        public InputMessagesFilterVoice()
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
            return "inputMessagesFilterVoice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessagesFilterVoice();
            return newClonedObject;

        }
#nullable disable
    }
}
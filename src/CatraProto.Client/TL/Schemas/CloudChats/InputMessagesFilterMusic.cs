using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterMusic : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 928101534; }



        public InputMessagesFilterMusic()
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
            return "inputMessagesFilterMusic";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
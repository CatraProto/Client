using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyAddedByPhone : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1124062251; }



        public PrivacyKeyAddedByPhone()
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
            return "privacyKeyAddedByPhone";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
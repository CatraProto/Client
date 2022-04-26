using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueTypePersonalDetails : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1658158621; }



        public SecureValueTypePersonalDetails()
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
            return "secureValueTypePersonalDetails";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueTypePersonalDetails();
            return newClonedObject;

        }
#nullable disable
    }
}
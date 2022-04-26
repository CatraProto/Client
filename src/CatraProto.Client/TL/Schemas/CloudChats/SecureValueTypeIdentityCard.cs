using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueTypeIdentityCard : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1596951477; }



        public SecureValueTypeIdentityCard()
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
            return "secureValueTypeIdentityCard";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueTypeIdentityCard();
            return newClonedObject;

        }
#nullable disable
    }
}
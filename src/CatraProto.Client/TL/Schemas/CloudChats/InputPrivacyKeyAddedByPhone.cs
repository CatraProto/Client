using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyKeyAddedByPhone : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -786326563; }



        public InputPrivacyKeyAddedByPhone()
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
            return "inputPrivacyKeyAddedByPhone";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPrivacyKeyAddedByPhone();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPrivacyKeyAddedByPhone castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyPhoneNumber : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -778378131; }



        public PrivacyKeyPhoneNumber()
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
            return "privacyKeyPhoneNumber";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PrivacyKeyPhoneNumber();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PrivacyKeyPhoneNumber castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
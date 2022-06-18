using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyKeyPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -88417185; }



        public InputPrivacyKeyPhoneCall()
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
            return "inputPrivacyKeyPhoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPrivacyKeyPhoneCall();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPrivacyKeyPhoneCall castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
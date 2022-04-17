using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePhoneCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1425052898; }

        [Newtonsoft.Json.JsonProperty("phone_call")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall { get; set; }


#nullable enable
        public UpdatePhoneCall(CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase phoneCall)
        {
            PhoneCall = phoneCall;

        }
#nullable disable
        internal UpdatePhoneCall()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkphoneCall = writer.WriteObject(PhoneCall);
            if (checkphoneCall.IsError)
            {
                return checkphoneCall;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
            if (tryphoneCall.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCall);
            }
            PhoneCall = tryphoneCall.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePhoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
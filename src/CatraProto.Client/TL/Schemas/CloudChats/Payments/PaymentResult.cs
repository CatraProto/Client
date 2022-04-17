using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class PaymentResult : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1314881805; }

        [Newtonsoft.Json.JsonProperty("updates")]
        public CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase Updates { get; set; }


#nullable enable
        public PaymentResult(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase updates)
        {
            Updates = updates;

        }
#nullable disable
        internal PaymentResult()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdates = writer.WriteObject(Updates);
            if (checkupdates.IsError)
            {
                return checkupdates;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdates = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
            if (tryupdates.IsError)
            {
                return ReadResult<IObject>.Move(tryupdates);
            }
            Updates = tryupdates.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.paymentResult";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
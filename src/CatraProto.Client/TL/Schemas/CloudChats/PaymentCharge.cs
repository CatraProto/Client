using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PaymentCharge : CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -368917890; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_charge_id")]
        public sealed override string ProviderChargeId { get; set; }


#nullable enable
        public PaymentCharge(string id, string providerChargeId)
        {
            Id = id;
            ProviderChargeId = providerChargeId;

        }
#nullable disable
        internal PaymentCharge()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(ProviderChargeId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryproviderChargeId = reader.ReadString();
            if (tryproviderChargeId.IsError)
            {
                return ReadResult<IObject>.Move(tryproviderChargeId);
            }
            ProviderChargeId = tryproviderChargeId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "paymentCharge";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
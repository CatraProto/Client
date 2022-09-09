using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PaymentCharge : CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -368917890; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentCharge();
            newClonedObject.Id = Id;
            newClonedObject.ProviderChargeId = ProviderChargeId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentCharge castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (ProviderChargeId != castedOther.ProviderChargeId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
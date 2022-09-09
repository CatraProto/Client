using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class PaymentVerificationNeeded : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -666824391; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }


#nullable enable
        public PaymentVerificationNeeded(string url)
        {
            Url = url;
        }
#nullable disable
        internal PaymentVerificationNeeded()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.paymentVerificationNeeded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentVerificationNeeded();
            newClonedObject.Url = Url;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentVerificationNeeded castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
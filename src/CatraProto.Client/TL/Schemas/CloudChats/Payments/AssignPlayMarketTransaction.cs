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
    public partial class AssignPlayMarketTransaction : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1336560365; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("purchase_token")]
        public string PurchaseToken { get; set; }


#nullable enable
        public AssignPlayMarketTransaction(string purchaseToken)
        {
            PurchaseToken = purchaseToken;
        }
#nullable disable

        internal AssignPlayMarketTransaction()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PurchaseToken);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypurchaseToken = reader.ReadString();
            if (trypurchaseToken.IsError)
            {
                return ReadResult<IObject>.Move(trypurchaseToken);
            }

            PurchaseToken = trypurchaseToken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.assignPlayMarketTransaction";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AssignPlayMarketTransaction();
            newClonedObject.PurchaseToken = PurchaseToken;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AssignPlayMarketTransaction castedOther)
            {
                return true;
            }

            if (PurchaseToken != castedOther.PurchaseToken)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
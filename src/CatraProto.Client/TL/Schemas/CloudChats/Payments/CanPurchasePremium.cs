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
    public partial class CanPurchasePremium : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1435856696; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;


        public CanPurchasePremium()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.canPurchasePremium";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CanPurchasePremium();
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CanPurchasePremium castedOther)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
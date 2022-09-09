using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class UpdateDialogFiltersOrder : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -983318044; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("order")]
        public List<int> Order { get; set; }


#nullable enable
        public UpdateDialogFiltersOrder(List<int> order)
        {
            Order = order;
        }
#nullable disable

        internal UpdateDialogFiltersOrder()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Order, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryorder = reader.ReadVector<int>(ParserTypes.Int);
            if (tryorder.IsError)
            {
                return ReadResult<IObject>.Move(tryorder);
            }

            Order = tryorder.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.updateDialogFiltersOrder";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateDialogFiltersOrder();
            newClonedObject.Order = new List<int>();
            foreach (var order in Order)
            {
                newClonedObject.Order.Add(order);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateDialogFiltersOrder castedOther)
            {
                return true;
            }

            var ordersize = castedOther.Order.Count;
            if (ordersize != Order.Count)
            {
                return true;
            }

            for (var i = 0; i < ordersize; i++)
            {
                if (castedOther.Order[i] != Order[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}
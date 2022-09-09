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
    public partial class UpdateDialogFilterOrder : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1512627963; }

        [Newtonsoft.Json.JsonProperty("order")]
        public List<int> Order { get; set; }


#nullable enable
        public UpdateDialogFilterOrder(List<int> order)
        {
            Order = order;
        }
#nullable disable
        internal UpdateDialogFilterOrder()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Order, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
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
            return "updateDialogFilterOrder";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDialogFilterOrder();
            newClonedObject.Order = new List<int>();
            foreach (var order in Order)
            {
                newClonedObject.Order.Add(order);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateDialogFilterOrder castedOther)
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
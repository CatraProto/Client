using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class UpdateDialogFiltersOrder : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -983318044;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("order")]
        public IList<int> Order { get; set; }


    #nullable enable
        public UpdateDialogFiltersOrder(IList<int> order)
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

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Order);
        }

        public void Deserialize(Reader reader)
        {
            Order = reader.ReadVector<int>();
        }

        public override string ToString()
        {
            return "messages.updateDialogFiltersOrder";
        }
    }
}
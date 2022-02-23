using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeWithMessagesRange : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 911373810;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(IObject);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("range")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase Range { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


    #nullable enable
        public InvokeWithMessagesRange(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query)
        {
            Range = range;
            Query = query;
        }
    #nullable disable

        internal InvokeWithMessagesRange()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Range);
            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            Range = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
            Query = reader.Read<IObject>();
        }

        public override string ToString()
        {
            return "invokeWithMessagesRange";
        }
    }
}
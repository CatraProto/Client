using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeWithoutUpdates : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1080796745;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(IObject);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


    #nullable enable
        public InvokeWithoutUpdates(IObject query)
        {
            Query = query;
        }
    #nullable disable

        internal InvokeWithoutUpdates()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            Query = reader.Read<IObject>();
        }

        public override string ToString()
        {
            return "invokeWithoutUpdates";
        }
    }
}
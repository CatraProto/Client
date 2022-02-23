using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeAfterMsg : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -878758099;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(IObject);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


    #nullable enable
        public InvokeAfterMsg(long msgId, IObject query)
        {
            MsgId = msgId;
            Query = query;
        }
    #nullable disable

        internal InvokeAfterMsg()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MsgId);
            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            MsgId = reader.Read<long>();
            Query = reader.Read<IObject>();
        }

        public override string ToString()
        {
            return "invokeAfterMsg";
        }
    }
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GetGroupCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 68699611;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


    #nullable enable
        public GetGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, int limit)
        {
            Call = call;
            Limit = limit;
        }
    #nullable disable

        internal GetGroupCall()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Call);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            Limit = reader.Read<int>();
        }

        public override string ToString()
        {
            return "phone.getGroupCall";
        }
    }
}
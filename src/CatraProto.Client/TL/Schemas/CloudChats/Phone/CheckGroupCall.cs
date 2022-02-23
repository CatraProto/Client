using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class CheckGroupCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1248003721;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(int);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public IList<int> Sources { get; set; }


    #nullable enable
        public CheckGroupCall(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, IList<int> sources)
        {
            Call = call;
            Sources = sources;
        }
    #nullable disable

        internal CheckGroupCall()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Call);
            writer.Write(Sources);
        }

        public void Deserialize(Reader reader)
        {
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            Sources = reader.ReadVector<int>();
        }

        public override string ToString()
        {
            return "phone.checkGroupCall";
        }
    }
}
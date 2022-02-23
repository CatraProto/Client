using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SendCustomRequest : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1440257555;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("custom_method")]
        public string CustomMethod { get; set; }

        [Newtonsoft.Json.JsonProperty("params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


    #nullable enable
        public SendCustomRequest(string customMethod, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
        {
            CustomMethod = customMethod;
            Params = pparams;
        }
    #nullable disable

        internal SendCustomRequest()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(CustomMethod);
            writer.Write(Params);
        }

        public void Deserialize(Reader reader)
        {
            CustomMethod = reader.Read<string>();
            Params = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
        }

        public override string ToString()
        {
            return "bots.sendCustomRequest";
        }
    }
}
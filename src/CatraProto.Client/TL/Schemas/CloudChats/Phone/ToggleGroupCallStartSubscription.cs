using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ToggleGroupCallStartSubscription : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 563885286;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("subscribed")]
        public bool Subscribed { get; set; }


    #nullable enable
        public ToggleGroupCallStartSubscription(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool subscribed)
        {
            Call = call;
            Subscribed = subscribed;
        }
    #nullable disable

        internal ToggleGroupCallStartSubscription()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Call);
            writer.Write(Subscribed);
        }

        public void Deserialize(Reader reader)
        {
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            Subscribed = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "phone.toggleGroupCallStartSubscription";
        }
    }
}
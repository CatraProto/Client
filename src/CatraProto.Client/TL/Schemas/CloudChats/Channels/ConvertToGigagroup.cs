using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ConvertToGigagroup : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 187239529;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }


    #nullable enable
        public ConvertToGigagroup(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel)
        {
            Channel = channel;
        }
    #nullable disable

        internal ConvertToGigagroup()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Channel);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
        }

        public override string ToString()
        {
            return "channels.convertToGigagroup";
        }
    }
}
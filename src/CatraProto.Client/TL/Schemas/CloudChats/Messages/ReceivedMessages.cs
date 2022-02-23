using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReceivedMessages : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 94983360;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


    #nullable enable
        public ReceivedMessages(int maxId)
        {
            MaxId = maxId;
        }
    #nullable disable

        internal ReceivedMessages()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            MaxId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.receivedMessages";
        }
    }
}
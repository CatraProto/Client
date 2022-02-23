using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionBotAllowed : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1410748418;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("domain")]
        public string Domain { get; set; }


    #nullable enable
        public MessageActionBotAllowed(string domain)
        {
            Domain = domain;
        }
    #nullable disable
        internal MessageActionBotAllowed()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Domain);
        }

        public override void Deserialize(Reader reader)
        {
            Domain = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messageActionBotAllowed";
        }
    }
}
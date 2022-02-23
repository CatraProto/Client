using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionSetMessagesTTL : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1441072131;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }


    #nullable enable
        public MessageActionSetMessagesTTL(int period)
        {
            Period = period;
        }
    #nullable disable
        internal MessageActionSetMessagesTTL()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Period);
        }

        public override void Deserialize(Reader reader)
        {
            Period = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messageActionSetMessagesTTL";
        }
    }
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageMediaDice : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1065280907; }

        [Newtonsoft.Json.JsonProperty("value")]
        public int Value { get; set; }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }


#nullable enable
        public MessageMediaDice(int value, string emoticon)
        {
            Value = value;
            Emoticon = emoticon;

        }
#nullable disable
        internal MessageMediaDice()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Value);

            writer.WriteString(Emoticon);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadInt32();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            var tryemoticon = reader.ReadString();
            if (tryemoticon.IsError)
            {
                return ReadResult<IObject>.Move(tryemoticon);
            }
            Emoticon = tryemoticon.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageMediaDice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
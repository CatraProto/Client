using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaDice : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -428884101; }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }


#nullable enable
        public InputMediaDice(string emoticon)
        {
            Emoticon = emoticon;

        }
#nullable disable
        internal InputMediaDice()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Emoticon);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "inputMediaDice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
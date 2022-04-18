using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class TranslateResultText : CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1575684144; }

        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }


#nullable enable
        public TranslateResultText(string text)
        {
            Text = text;

        }
#nullable disable
        internal TranslateResultText()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.translateResultText";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
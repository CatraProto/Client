using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonUrl : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 629866245; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }


#nullable enable
        public KeyboardButtonUrl(string text, string url)
        {
            Text = text;
            Url = url;

        }
#nullable disable
        internal KeyboardButtonUrl()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteString(Url);

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
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "keyboardButtonUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonUrl
            {
                Text = Text,
                Url = Url
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonUrl castedOther)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            if (Url != castedOther.Url)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
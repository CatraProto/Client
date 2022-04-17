using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextSubscript : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -311786236; }

        [Newtonsoft.Json.JsonProperty("text")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


#nullable enable
        public TextSubscript(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Text = text;

        }
#nullable disable
        internal TextSubscript()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "textSubscript";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
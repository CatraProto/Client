using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockPreformatted : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1066346178; }

        [Newtonsoft.Json.JsonProperty("text")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("language")]
        public string Language { get; set; }


#nullable enable
        public PageBlockPreformatted(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string language)
        {
            Text = text;
            Language = language;

        }
#nullable disable
        internal PageBlockPreformatted()
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

            writer.WriteString(Language);

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
            var trylanguage = reader.ReadString();
            if (trylanguage.IsError)
            {
                return ReadResult<IObject>.Move(trylanguage);
            }
            Language = trylanguage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockPreformatted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockPreformatted();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }
            newClonedObject.Text = cloneText;
            newClonedObject.Language = Language;
            return newClonedObject;

        }
#nullable disable
    }
}
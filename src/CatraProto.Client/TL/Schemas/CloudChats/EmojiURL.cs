using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiURL : CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1519029347; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }


#nullable enable
        public EmojiURL(string url)
        {
            Url = url;

        }
#nullable disable
        internal EmojiURL()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "emojiURL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EmojiURL
            {
                Url = Url
            };
            return newClonedObject;

        }
#nullable disable
    }
}
#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromGetStickers : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2137406768; }

        [Newtonsoft.Json.JsonProperty("emoji")]
        public string Emoji { get; set; }


#nullable enable
        public ContextFromGetStickers(string emoji)
        {
            Emoji = emoji;
        }
#nullable disable
        internal ContextFromGetStickers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Emoji);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemoji = reader.ReadString();
            if (tryemoji.IsError)
            {
                return ReadResult<IObject>.Move(tryemoji);
            }

            Emoji = tryemoji.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromGetStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromGetStickers();
            newClonedObject.Emoji = Emoji;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromGetStickers castedOther)
            {
                return true;
            }

            if (Emoji != castedOther.Emoji)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
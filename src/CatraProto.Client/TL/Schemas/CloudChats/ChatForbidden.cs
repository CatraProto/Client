using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1704108455; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public ChatForbidden(long id, string title)
        {
            Id = id;
            Title = title;

        }
#nullable disable
        internal ChatForbidden()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            writer.WriteString(Title);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatForbidden";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatForbidden
            {
                Id = Id,
                Title = Title
            };
            return newClonedObject;

        }
#nullable disable
    }
}
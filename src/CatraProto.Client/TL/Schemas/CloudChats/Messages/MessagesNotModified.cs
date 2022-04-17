using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class MessagesNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1951620897; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }


#nullable enable
        public MessagesNotModified(int count)
        {
            Count = count;

        }
#nullable disable
        internal MessagesNotModified()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.messagesNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageUserVoteInputOption : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1017491692; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }


#nullable enable
        public MessageUserVoteInputOption(long userId, int date)
        {
            UserId = userId;
            Date = date;

        }
#nullable disable
        internal MessageUserVoteInputOption()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageUserVoteInputOption";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageUserVoteInputOption
            {
                UserId = UserId,
                Date = Date
            };
            return newClonedObject;

        }
#nullable disable
    }
}
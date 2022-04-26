using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantCreator : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -462696732; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }


#nullable enable
        public ChatParticipantCreator(long userId)
        {
            UserId = userId;

        }
#nullable disable
        internal ChatParticipantCreator()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatParticipantCreator";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatParticipantCreator
            {
                UserId = UserId
            };
            return newClonedObject;

        }
#nullable disable
    }
}
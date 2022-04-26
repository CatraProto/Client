using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageRange : CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 182649427; }

        [Newtonsoft.Json.JsonProperty("min_id")]
        public sealed override int MinId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public sealed override int MaxId { get; set; }


#nullable enable
        public MessageRange(int minId, int maxId)
        {
            MinId = minId;
            MaxId = maxId;

        }
#nullable disable
        internal MessageRange()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MinId);
            writer.WriteInt32(MaxId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryminId = reader.ReadInt32();
            if (tryminId.IsError)
            {
                return ReadResult<IObject>.Move(tryminId);
            }
            MinId = tryminId.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }
            MaxId = trymaxId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageRange";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageRange
            {
                MinId = MinId,
                MaxId = MaxId
            };
            return newClonedObject;

        }
#nullable disable
    }
}
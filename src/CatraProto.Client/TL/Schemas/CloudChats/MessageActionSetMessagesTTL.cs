using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionSetMessagesTTL : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1441072131; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }


#nullable enable
        public MessageActionSetMessagesTTL(int period)
        {
            Period = period;

        }
#nullable disable
        internal MessageActionSetMessagesTTL()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Period);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryperiod = reader.ReadInt32();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }
            Period = tryperiod.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionSetMessagesTTL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionSetMessagesTTL
            {
                Period = Period
            };
            return newClonedObject;

        }
#nullable disable
    }
}
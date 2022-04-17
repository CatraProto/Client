using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1272375192; }

        [Newtonsoft.Json.JsonProperty("poll")]
        public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }


#nullable enable
        public MessageMediaPoll(CatraProto.Client.TL.Schemas.CloudChats.PollBase poll, CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase results)
        {
            Poll = poll;
            Results = results;

        }
#nullable disable
        internal MessageMediaPoll()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpoll = writer.WriteObject(Poll);
            if (checkpoll.IsError)
            {
                return checkpoll;
            }
            var checkresults = writer.WriteObject(Results);
            if (checkresults.IsError)
            {
                return checkresults;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypoll = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
            if (trypoll.IsError)
            {
                return ReadResult<IObject>.Move(trypoll);
            }
            Poll = trypoll.Value;
            var tryresults = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();
            if (tryresults.IsError)
            {
                return ReadResult<IObject>.Move(tryresults);
            }
            Results = tryresults.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageMediaPoll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
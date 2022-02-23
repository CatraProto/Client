using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateMessagePollVote : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 274961865;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("poll_id")]
        public long PollId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("options")]
        public IList<byte[]> Options { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


    #nullable enable
        public UpdateMessagePollVote(long pollId, long userId, IList<byte[]> options, int qts)
        {
            PollId = pollId;
            UserId = userId;
            Options = options;
            Qts = qts;
        }
    #nullable disable
        internal UpdateMessagePollVote()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PollId);
            writer.Write(UserId);
            writer.Write(Options);
            writer.Write(Qts);
        }

        public override void Deserialize(Reader reader)
        {
            PollId = reader.Read<long>();
            UserId = reader.Read<long>();
            Options = reader.ReadVector<byte[]>();
            Qts = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateMessagePollVote";
        }
    }
}
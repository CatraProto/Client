using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateMessagePoll : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Poll = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1398708869;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("poll_id")]
        public long PollId { get; set; }

        [Newtonsoft.Json.JsonProperty("poll")] public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }


    #nullable enable
        public UpdateMessagePoll(long pollId, CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase results)
        {
            PollId = pollId;
            Results = results;
        }
    #nullable disable
        internal UpdateMessagePoll()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Poll == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(PollId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Poll);
            }

            writer.Write(Results);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            PollId = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
            }

            Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();
        }

        public override string ToString()
        {
            return "updateMessagePoll";
        }
    }
}
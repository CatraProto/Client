using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AffectedMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase
    {
        public static int StaticConstructorId
        {
            get => -2066640507;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("pts")] public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public sealed override int PtsCount { get; set; }


    #nullable enable
        public AffectedMessages(int pts, int ptsCount)
        {
            Pts = pts;
            PtsCount = ptsCount;
        }
    #nullable disable
        internal AffectedMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.affectedMessages";
        }
    }
}
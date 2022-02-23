using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGroupTopInviter : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase
    {
        public static int StaticConstructorId
        {
            get => 1398765469;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("invitations")]
        public sealed override int Invitations { get; set; }


    #nullable enable
        public StatsGroupTopInviter(long userId, int invitations)
        {
            UserId = userId;
            Invitations = invitations;
        }
    #nullable disable
        internal StatsGroupTopInviter()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Invitations);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
            Invitations = reader.Read<int>();
        }

        public override string ToString()
        {
            return "statsGroupTopInviter";
        }
    }
}
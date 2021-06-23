using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class StatsGroupTopInviter : StatsGroupTopInviterBase
    {
        public static int ConstructorId { get; } = 831924812;
        public override int UserId { get; set; }
        public override int Invitations { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(UserId);
            writer.Write(Invitations);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            Invitations = reader.Read<int>();
        }
    }
}
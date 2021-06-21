using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGroupTopAdmin : StatsGroupTopAdminBase
    {
        public static int ConstructorId { get; } = 1611985938;
        public override int UserId { get; set; }
        public override int Deleted { get; set; }
        public override int Kicked { get; set; }
        public override int Banned { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Deleted);
            writer.Write(Kicked);
            writer.Write(Banned);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            Deleted = reader.Read<int>();
            Kicked = reader.Read<int>();
            Banned = reader.Read<int>();
        }
    }
}
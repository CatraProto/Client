using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageUserVote : MessageUserVoteBase
    {
        public static int ConstructorId { get; } = -1567730343;
        public override int UserId { get; set; }
        public byte[] Option { get; set; }
        public override int Date { get; set; }

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
            writer.Write(Option);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            Option = reader.Read<byte[]>();
            Date = reader.Read<int>();
        }
    }
}
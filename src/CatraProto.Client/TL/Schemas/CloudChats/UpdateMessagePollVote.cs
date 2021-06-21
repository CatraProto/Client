using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateMessagePollVote : UpdateBase
    {
        public static int ConstructorId { get; } = 1123585836;
        public long PollId { get; set; }
        public int UserId { get; set; }
        public IList<byte[]> Options { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PollId);
            writer.Write(UserId);
            writer.Write(Options);
        }

        public override void Deserialize(Reader reader)
        {
            PollId = reader.Read<long>();
            UserId = reader.Read<int>();
            Options = reader.ReadVector<byte[]>();
        }
    }
}
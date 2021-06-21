using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageUserVoteMultiple : MessageUserVoteBase
    {
        public static int ConstructorId { get; } = 244310238;
        public override int UserId { get; set; }
        public IList<byte[]> Options { get; set; }
        public override int Date { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(UserId);
            writer.Write(Options);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            Options = reader.ReadVector<byte[]>();
            Date = reader.Read<int>();
        }
    }
}
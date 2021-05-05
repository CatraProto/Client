using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipant : ChannelParticipantBase
    {
        public static int ConstructorId { get; } = -791039645;
        public override ChannelParticipantBase Participant { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Participant);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Participant = reader.Read<ChannelParticipantBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}
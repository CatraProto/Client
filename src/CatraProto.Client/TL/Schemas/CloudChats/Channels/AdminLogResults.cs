using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class AdminLogResults : AdminLogResultsBase
    {
        public static int ConstructorId { get; } = -309659827;
        public override IList<ChannelAdminLogEventBase> Events { get; set; }
        public override IList<ChatBase> Chats { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Events);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Events = reader.ReadVector<ChannelAdminLogEventBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}
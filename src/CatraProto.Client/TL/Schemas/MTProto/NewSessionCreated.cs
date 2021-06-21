using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class NewSessionCreated : NewSessionBase
    {
        public static int ConstructorId { get; } = -1631450872;
        public override long FirstMsgId { get; set; }
        public override long UniqueId { get; set; }
        public override long ServerSalt { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(FirstMsgId);
            writer.Write(UniqueId);
            writer.Write(ServerSalt);
        }

        public override void Deserialize(Reader reader)
        {
            FirstMsgId = reader.Read<long>();
            UniqueId = reader.Read<long>();
            ServerSalt = reader.Read<long>();
        }
    }
}
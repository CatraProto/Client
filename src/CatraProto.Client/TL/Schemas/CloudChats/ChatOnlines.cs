using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatOnlines : ChatOnlinesBase
    {
        public static int ConstructorId { get; } = -264117680;
        public override int Onlines { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Onlines);
        }

        public override void Deserialize(Reader reader)
        {
            Onlines = reader.Read<int>();
        }
    }
}
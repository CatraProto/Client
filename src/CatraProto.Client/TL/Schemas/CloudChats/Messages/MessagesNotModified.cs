using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class MessagesNotModified : MessagesBase
    {
        public static int ConstructorId { get; } = 1951620897;
        public int Count { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Count);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
        }
    }
}
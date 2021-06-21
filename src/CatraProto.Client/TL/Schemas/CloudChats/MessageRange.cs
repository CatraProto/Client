using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageRange : MessageRangeBase
    {
        public static int ConstructorId { get; } = 182649427;
        public override int MinId { get; set; }
        public override int MaxId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(MinId);
            writer.Write(MaxId);
        }

        public override void Deserialize(Reader reader)
        {
            MinId = reader.Read<int>();
            MaxId = reader.Read<int>();
        }
    }
}
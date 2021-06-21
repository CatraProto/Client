using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageMediaDice : MessageMediaBase
    {
        public static int ConstructorId { get; } = 1065280907;
        public int Value { get; set; }
        public string Emoticon { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Value);
            writer.Write(Emoticon);
        }

        public override void Deserialize(Reader reader)
        {
            Value = reader.Read<int>();
            Emoticon = reader.Read<string>();
        }
    }
}
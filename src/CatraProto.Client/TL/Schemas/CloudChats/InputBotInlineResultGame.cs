using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputBotInlineResultGame : InputBotInlineResultBase
    {
        public static int ConstructorId { get; } = 1336154098;
        public override string Id { get; set; }
        public string ShortName { get; set; }
        public override InputBotInlineMessageBase SendMessage { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
            writer.Write(ShortName);
            writer.Write(SendMessage);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<string>();
            ShortName = reader.Read<string>();
            SendMessage = reader.Read<InputBotInlineMessageBase>();
        }
    }
}
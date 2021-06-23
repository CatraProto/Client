using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetFullChat : IMethod
    {
        public static int ConstructorId { get; } = 998448230;

        public System.Type Type { get; init; } = typeof(ChatFullBase);
        public bool IsVector { get; init; } = false;
        public int ChatId { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
        }
    }
}
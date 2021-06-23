using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class ReceivedMessages : IMethod
    {
        public static int ConstructorId { get; } = 94983360;

        public System.Type Type { get; init; } = typeof(ReceivedNotifyMessageBase);
        public bool IsVector { get; init; } = false;
        public int MaxId { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            MaxId = reader.Read<int>();
        }
    }
}
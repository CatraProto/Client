using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetAllStickers : IMethod
    {
        public static int ConstructorId { get; } = 479598769;

        public System.Type Type { get; init; } = typeof(AllStickersBase);
        public bool IsVector { get; init; } = false;
        public int Hash { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
        }
    }
}
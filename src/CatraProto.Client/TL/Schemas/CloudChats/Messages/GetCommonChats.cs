using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetCommonChats : IMethod
    {
        public static int ConstructorId { get; } = 218777796;

        public System.Type Type { get; init; } = typeof(ChatsBase);
        public bool IsVector { get; init; } = false;
        public InputUserBase UserId { get; set; }
        public int MaxId { get; set; }
        public int Limit { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(UserId);
            writer.Write(MaxId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
            MaxId = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}
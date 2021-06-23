using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class GetUserInfo : IMethod
    {
        public static int ConstructorId { get; } = 59377875;

        public System.Type Type { get; init; } = typeof(UserInfoBase);
        public bool IsVector { get; init; } = false;
        public InputUserBase UserId { get; set; }

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
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
        }
    }
}
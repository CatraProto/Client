using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public class CheckPassword : IMethod
    {
        public static int ConstructorId { get; } = -779399914;

        public Type Type { get; init; } = typeof(AuthorizationBase);
        public bool IsVector { get; init; } = false;
        public InputCheckPasswordSRPBase Password { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Password);
        }

        public void Deserialize(Reader reader)
        {
            Password = reader.Read<InputCheckPasswordSRPBase>();
        }
    }
}
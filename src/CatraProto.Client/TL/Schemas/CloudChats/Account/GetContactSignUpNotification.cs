using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetContactSignUpNotification : IMethod<bool>
    {
        public static int ConstructorId { get; } = -1626880216;

        public Type Type { get; init; } = typeof(GetContactSignUpNotification);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
        }

        public void Deserialize(Reader reader)
        {
        }
    }
}
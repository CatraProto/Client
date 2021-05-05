using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LogOut : IMethod<bool>
    {
        public static int ConstructorId { get; } = 1461180992;

        public Type Type { get; init; } = typeof(LogOut);
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
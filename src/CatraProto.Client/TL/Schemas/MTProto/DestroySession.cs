using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DestroySession : IMethod
    {
        public static int ConstructorId { get; } = -414113498;
        public long SessionId { get; set; }

        public Type Type { get; init; } = typeof(DestroySessionResBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(SessionId);
        }

        public void Deserialize(Reader reader)
        {
            SessionId = reader.Read<long>();
        }
    }
}
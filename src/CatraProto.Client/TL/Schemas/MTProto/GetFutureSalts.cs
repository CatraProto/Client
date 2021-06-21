using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GetFutureSalts : IMethod
    {
        public static int ConstructorId { get; } = -1188971260;
        public int Num { get; set; }

        public Type Type { get; init; } = typeof(FutureSaltsBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Num);
        }

        public void Deserialize(Reader reader)
        {
            Num = reader.Read<int>();
        }
    }
}
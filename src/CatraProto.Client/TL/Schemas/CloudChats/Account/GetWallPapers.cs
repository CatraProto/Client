using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetWallPapers : IMethod
    {
        public static int ConstructorId { get; } = -1430579357;
        public int Hash { get; set; }

        public Type Type { get; init; } = typeof(WallPapersBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
        }
    }
}
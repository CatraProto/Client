using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetWebFile : IMethod
    {
        public static int ConstructorId { get; } = 619086221;
        public InputWebFileLocationBase Location { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }

        public Type Type { get; init; } = typeof(WebFileBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Location);
            writer.Write(Offset);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Location = reader.Read<InputWebFileLocationBase>();
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}
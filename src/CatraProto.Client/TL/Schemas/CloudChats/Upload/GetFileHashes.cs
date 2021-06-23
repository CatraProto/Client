using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public class GetFileHashes : IMethod
    {
        public static int ConstructorId { get; } = -956147407;

        public System.Type Type { get; init; } = typeof(FileHashBase);
        public bool IsVector { get; init; } = false;
        public InputFileLocationBase Location { get; set; }
        public int Offset { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Location);
            writer.Write(Offset);
        }

        public void Deserialize(Reader reader)
        {
            Location = reader.Read<InputFileLocationBase>();
            Offset = reader.Read<int>();
        }
    }
}
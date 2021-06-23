using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public class SaveBigFilePart : IMethod
    {
        public static int ConstructorId { get; } = -562337987;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public long FileId { get; set; }
        public int FilePart { get; set; }
        public int FileTotalParts { get; set; }
        public byte[] Bytes { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(FileId);
            writer.Write(FilePart);
            writer.Write(FileTotalParts);
            writer.Write(Bytes);
        }

        public void Deserialize(Reader reader)
        {
            FileId = reader.Read<long>();
            FilePart = reader.Read<int>();
            FileTotalParts = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }
    }
}
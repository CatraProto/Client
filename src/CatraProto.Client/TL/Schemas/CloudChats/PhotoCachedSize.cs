using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PhotoCachedSize : PhotoSizeBase
    {
        public static int ConstructorId { get; } = -374917894;
        public override string Type { get; set; }
        public FileLocationBase Location { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public byte[] Bytes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Type);
            writer.Write(Location);
            writer.Write(W);
            writer.Write(H);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Type = reader.Read<string>();
            Location = reader.Read<FileLocationBase>();
            W = reader.Read<int>();
            H = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }
    }
}
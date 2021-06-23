using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public class DeleteFolder : IMethod
    {
        public static int ConstructorId { get; } = 472471681;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public int FolderId { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(FolderId);
        }

        public void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }
    }
}
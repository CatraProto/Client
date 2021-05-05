using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public partial class DeleteFolder : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = 472471681;
        public int FolderId { get; set; }

        public Type Type { get; init; } = typeof(DeleteFolder);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(FolderId);
        }

        public void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }
    }
}
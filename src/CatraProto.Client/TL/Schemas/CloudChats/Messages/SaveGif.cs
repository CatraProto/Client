using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SaveGif : IMethod
    {
        public static int ConstructorId { get; } = 846868683;
        public InputDocumentBase Id { get; set; }
        public bool Unsave { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Unsave);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputDocumentBase>();
            Unsave = reader.Read<bool>();
        }
    }
}
using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Block : IMethod<bool>
    {
        public static int ConstructorId { get; } = 1758204945;
        public InputPeerBase Id { get; set; }

        public Type Type { get; init; } = typeof(Block);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPeerBase>();
        }
    }
}
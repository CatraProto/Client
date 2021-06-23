using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public class Block : IMethod
    {
        public static int ConstructorId { get; } = 1758204945;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPeerBase>();
        }
    }
}
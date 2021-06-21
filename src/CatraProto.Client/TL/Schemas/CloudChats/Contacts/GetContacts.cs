using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetContacts : IMethod
    {
        public static int ConstructorId { get; } = -1071414113;
        public int Hash { get; set; }

        public Type Type { get; init; } = typeof(ContactsBase);
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
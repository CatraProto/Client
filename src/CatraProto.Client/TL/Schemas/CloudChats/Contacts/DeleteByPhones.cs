using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class DeleteByPhones : IMethod
    {
        public static int ConstructorId { get; } = 269745566;
        public IList<string> Phones { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Phones);
        }

        public void Deserialize(Reader reader)
        {
            Phones = reader.ReadVector<string>();
        }
    }
}
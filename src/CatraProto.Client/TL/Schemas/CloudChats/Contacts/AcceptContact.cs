using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class AcceptContact : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = -130964977;
        public InputUserBase Id { get; set; }

        public Type Type { get; init; } = typeof(AcceptContact);
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
            Id = reader.Read<InputUserBase>();
        }
    }
}
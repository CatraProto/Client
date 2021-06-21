using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResolveUsername : IMethod
    {
        public static int ConstructorId { get; } = -113456221;
        public string Username { get; set; }

        public Type Type { get; init; } = typeof(ResolvedPeerBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Username);
        }

        public void Deserialize(Reader reader)
        {
            Username = reader.Read<string>();
        }
    }
}
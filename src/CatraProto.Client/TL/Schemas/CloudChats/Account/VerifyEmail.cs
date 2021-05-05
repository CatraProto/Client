using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class VerifyEmail : IMethod<bool>
    {
        public static int ConstructorId { get; } = -323339813;
        public string Email { get; set; }
        public string Code { get; set; }

        public Type Type { get; init; } = typeof(VerifyEmail);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Email);
            writer.Write(Code);
        }

        public void Deserialize(Reader reader)
        {
            Email = reader.Read<string>();
            Code = reader.Read<string>();
        }
    }
}
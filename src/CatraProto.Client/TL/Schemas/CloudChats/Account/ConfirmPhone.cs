using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ConfirmPhone : IMethod
    {
        public static int ConstructorId { get; } = 1596029123;
        public string PhoneCodeHash { get; set; }
        public string PhoneCode { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PhoneCodeHash);
            writer.Write(PhoneCode);
        }

        public void Deserialize(Reader reader)
        {
            PhoneCodeHash = reader.Read<string>();
            PhoneCode = reader.Read<string>();
        }
    }
}
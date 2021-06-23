using System;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class SendVerifyPhoneCode : IMethod
    {
        public static int ConstructorId { get; } = -1516022023;

        public Type Type { get; init; } = typeof(SentCodeBase);
        public bool IsVector { get; init; } = false;
        public string PhoneNumber { get; set; }
        public CodeSettingsBase Settings { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(PhoneNumber);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            Settings = reader.Read<CodeSettingsBase>();
        }
    }
}
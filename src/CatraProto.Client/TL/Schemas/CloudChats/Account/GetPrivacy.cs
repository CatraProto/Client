using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetPrivacy : IMethod
    {
        public static int ConstructorId { get; } = -623130288;
        public InputPrivacyKeyBase Key { get; set; }

        public Type Type { get; init; } = typeof(PrivacyRulesBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Key);
        }

        public void Deserialize(Reader reader)
        {
            Key = reader.Read<InputPrivacyKeyBase>();
        }
    }
}
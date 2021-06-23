using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class SetGlobalPrivacySettings : IMethod
    {
        public static int ConstructorId { get; } = 517647042;

        public Type Type { get; init; } = typeof(GlobalPrivacySettingsBase);
        public bool IsVector { get; init; } = false;
        public GlobalPrivacySettingsBase Settings { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            Settings = reader.Read<GlobalPrivacySettingsBase>();
        }
    }
}
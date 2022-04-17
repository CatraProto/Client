using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetGlobalPrivacySettings : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 517647042; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase Settings { get; set; }


#nullable enable
        public SetGlobalPrivacySettings(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase settings)
        {
            Settings = settings;

        }
#nullable disable

        internal SetGlobalPrivacySettings()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();
            if (trysettings.IsError)
            {
                return ReadResult<IObject>.Move(trysettings);
            }
            Settings = trysettings.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.setGlobalPrivacySettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
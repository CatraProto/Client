using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdatePasswordSettings : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1516564433; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

        [Newtonsoft.Json.JsonProperty("new_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }


#nullable enable
        public UpdatePasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings)
        {
            Password = password;
            NewSettings = newSettings;
        }
#nullable disable

        internal UpdatePasswordSettings()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpassword = writer.WriteObject(Password);
            if (checkpassword.IsError)
            {
                return checkpassword;
            }

            var checknewSettings = writer.WriteObject(NewSettings);
            if (checknewSettings.IsError)
            {
                return checknewSettings;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypassword = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
            if (trypassword.IsError)
            {
                return ReadResult<IObject>.Move(trypassword);
            }

            Password = trypassword.Value;
            var trynewSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();
            if (trynewSettings.IsError)
            {
                return ReadResult<IObject>.Move(trynewSettings);
            }

            NewSettings = trynewSettings.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updatePasswordSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdatePasswordSettings();
            var clonePassword = (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase?)Password.Clone();
            if (clonePassword is null)
            {
                return null;
            }

            newClonedObject.Password = clonePassword;
            var cloneNewSettings = (CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase?)NewSettings.Clone();
            if (cloneNewSettings is null)
            {
                return null;
            }

            newClonedObject.NewSettings = cloneNewSettings;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdatePasswordSettings castedOther)
            {
                return true;
            }

            if (Password.Compare(castedOther.Password))
            {
                return true;
            }

            if (NewSettings.Compare(castedOther.NewSettings))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
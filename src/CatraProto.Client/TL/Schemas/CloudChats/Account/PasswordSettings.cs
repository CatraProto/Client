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
    public partial class PasswordSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Email = 1 << 0,
            SecureSettings = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1705233435; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public sealed override string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("secure_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase SecureSettings { get; set; }


        public PasswordSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SecureSettings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Email);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksecureSettings = writer.WriteObject(SecureSettings);
                if (checksecureSettings.IsError)
                {
                    return checksecureSettings;
                }
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryemail = reader.ReadString();
                if (tryemail.IsError)
                {
                    return ReadResult<IObject>.Move(tryemail);
                }

                Email = tryemail.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysecureSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase>();
                if (trysecureSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trysecureSettings);
                }

                SecureSettings = trysecureSettings.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.passwordSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PasswordSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.Email = Email;
            if (SecureSettings is not null)
            {
                var cloneSecureSettings = (CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase?)SecureSettings.Clone();
                if (cloneSecureSettings is null)
                {
                    return null;
                }

                newClonedObject.SecureSettings = cloneSecureSettings;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PasswordSettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Email != castedOther.Email)
            {
                return true;
            }

            if (SecureSettings is null && castedOther.SecureSettings is not null || SecureSettings is not null && castedOther.SecureSettings is null)
            {
                return true;
            }

            if (SecureSettings is not null && castedOther.SecureSettings is not null && SecureSettings.Compare(castedOther.SecureSettings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
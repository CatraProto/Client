using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class PasswordInputSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NewAlgo = 1 << 0,
            NewPasswordHash = 1 << 0,
            Hint = 1 << 0,
            Email = 1 << 1,
            NewSecureSettings = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1036572727; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_algo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("new_password_hash")]
        public sealed override byte[] NewPasswordHash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("hint")]
        public sealed override string Hint { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public sealed override string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_secure_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase NewSecureSettings { get; set; }



        public PasswordInputSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NewAlgo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = NewPasswordHash == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Hint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = NewSecureSettings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checknewAlgo = writer.WriteObject(NewAlgo);
                if (checknewAlgo.IsError)
                {
                    return checknewAlgo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteBytes(NewPasswordHash);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(Hint);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(Email);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checknewSecureSettings = writer.WriteObject(NewSecureSettings);
                if (checknewSecureSettings.IsError)
                {
                    return checknewSecureSettings;
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
                var trynewAlgo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
                if (trynewAlgo.IsError)
                {
                    return ReadResult<IObject>.Move(trynewAlgo);
                }
                NewAlgo = trynewAlgo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trynewPasswordHash = reader.ReadBytes();
                if (trynewPasswordHash.IsError)
                {
                    return ReadResult<IObject>.Move(trynewPasswordHash);
                }
                NewPasswordHash = trynewPasswordHash.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryhint = reader.ReadString();
                if (tryhint.IsError)
                {
                    return ReadResult<IObject>.Move(tryhint);
                }
                Hint = tryhint.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryemail = reader.ReadString();
                if (tryemail.IsError)
                {
                    return ReadResult<IObject>.Move(tryemail);
                }
                Email = tryemail.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trynewSecureSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase>();
                if (trynewSecureSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trynewSecureSettings);
                }
                NewSecureSettings = trynewSecureSettings.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.passwordInputSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
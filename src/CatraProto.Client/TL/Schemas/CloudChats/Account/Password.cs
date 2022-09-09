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
    public partial class Password : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasRecovery = 1 << 0,
            HasSecureValues = 1 << 1,
            HasPassword = 1 << 2,
            CurrentAlgo = 1 << 2,
            SrpB = 1 << 2,
            SrpId = 1 << 2,
            Hint = 1 << 3,
            EmailUnconfirmedPattern = 1 << 4,
            PendingResetDate = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 408623183; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_recovery")]
        public sealed override bool HasRecovery { get; set; }

        [Newtonsoft.Json.JsonProperty("has_secure_values")]
        public sealed override bool HasSecureValues { get; set; }

        [Newtonsoft.Json.JsonProperty("has_password")]
        public sealed override bool HasPassword { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("current_algo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("srp_B")]
        public sealed override byte[] SrpB { get; set; }

        [Newtonsoft.Json.JsonProperty("srp_id")]
        public sealed override long? SrpId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("hint")]
        public sealed override string Hint { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email_unconfirmed_pattern")]
        public sealed override string EmailUnconfirmedPattern { get; set; }

        [Newtonsoft.Json.JsonProperty("new_algo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("new_secure_algo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_random")]
        public sealed override byte[] SecureRandom { get; set; }

        [Newtonsoft.Json.JsonProperty("pending_reset_date")]
        public sealed override int? PendingResetDate { get; set; }


#nullable enable
        public Password(CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase newAlgo, CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase newSecureAlgo, byte[] secureRandom)
        {
            NewAlgo = newAlgo;
            NewSecureAlgo = newSecureAlgo;
            SecureRandom = secureRandom;
        }
#nullable disable
        internal Password()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HasRecovery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = HasSecureValues ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = HasPassword ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = CurrentAlgo == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = SrpB == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = SrpId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Hint == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = EmailUnconfirmedPattern == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PendingResetDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkcurrentAlgo = writer.WriteObject(CurrentAlgo);
                if (checkcurrentAlgo.IsError)
                {
                    return checkcurrentAlgo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteBytes(SrpB);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt64(SrpId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Hint);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteString(EmailUnconfirmedPattern);
            }

            var checknewAlgo = writer.WriteObject(NewAlgo);
            if (checknewAlgo.IsError)
            {
                return checknewAlgo;
            }

            var checknewSecureAlgo = writer.WriteObject(NewSecureAlgo);
            if (checknewSecureAlgo.IsError)
            {
                return checknewSecureAlgo;
            }

            writer.WriteBytes(SecureRandom);
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(PendingResetDate.Value);
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
            HasRecovery = FlagsHelper.IsFlagSet(Flags, 0);
            HasSecureValues = FlagsHelper.IsFlagSet(Flags, 1);
            HasPassword = FlagsHelper.IsFlagSet(Flags, 2);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trycurrentAlgo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
                if (trycurrentAlgo.IsError)
                {
                    return ReadResult<IObject>.Move(trycurrentAlgo);
                }

                CurrentAlgo = trycurrentAlgo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trysrpB = reader.ReadBytes();
                if (trysrpB.IsError)
                {
                    return ReadResult<IObject>.Move(trysrpB);
                }

                SrpB = trysrpB.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trysrpId = reader.ReadInt64();
                if (trysrpId.IsError)
                {
                    return ReadResult<IObject>.Move(trysrpId);
                }

                SrpId = trysrpId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryhint = reader.ReadString();
                if (tryhint.IsError)
                {
                    return ReadResult<IObject>.Move(tryhint);
                }

                Hint = tryhint.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryemailUnconfirmedPattern = reader.ReadString();
                if (tryemailUnconfirmedPattern.IsError)
                {
                    return ReadResult<IObject>.Move(tryemailUnconfirmedPattern);
                }

                EmailUnconfirmedPattern = tryemailUnconfirmedPattern.Value;
            }

            var trynewAlgo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
            if (trynewAlgo.IsError)
            {
                return ReadResult<IObject>.Move(trynewAlgo);
            }

            NewAlgo = trynewAlgo.Value;
            var trynewSecureAlgo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase>();
            if (trynewSecureAlgo.IsError)
            {
                return ReadResult<IObject>.Move(trynewSecureAlgo);
            }

            NewSecureAlgo = trynewSecureAlgo.Value;
            var trysecureRandom = reader.ReadBytes();
            if (trysecureRandom.IsError)
            {
                return ReadResult<IObject>.Move(trysecureRandom);
            }

            SecureRandom = trysecureRandom.Value;
            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var trypendingResetDate = reader.ReadInt32();
                if (trypendingResetDate.IsError)
                {
                    return ReadResult<IObject>.Move(trypendingResetDate);
                }

                PendingResetDate = trypendingResetDate.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.password";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Password();
            newClonedObject.Flags = Flags;
            newClonedObject.HasRecovery = HasRecovery;
            newClonedObject.HasSecureValues = HasSecureValues;
            newClonedObject.HasPassword = HasPassword;
            if (CurrentAlgo is not null)
            {
                var cloneCurrentAlgo = (CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase?)CurrentAlgo.Clone();
                if (cloneCurrentAlgo is null)
                {
                    return null;
                }

                newClonedObject.CurrentAlgo = cloneCurrentAlgo;
            }

            newClonedObject.SrpB = SrpB;
            newClonedObject.SrpId = SrpId;
            newClonedObject.Hint = Hint;
            newClonedObject.EmailUnconfirmedPattern = EmailUnconfirmedPattern;
            var cloneNewAlgo = (CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase?)NewAlgo.Clone();
            if (cloneNewAlgo is null)
            {
                return null;
            }

            newClonedObject.NewAlgo = cloneNewAlgo;
            var cloneNewSecureAlgo = (CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase?)NewSecureAlgo.Clone();
            if (cloneNewSecureAlgo is null)
            {
                return null;
            }

            newClonedObject.NewSecureAlgo = cloneNewSecureAlgo;
            newClonedObject.SecureRandom = SecureRandom;
            newClonedObject.PendingResetDate = PendingResetDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Password castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (HasRecovery != castedOther.HasRecovery)
            {
                return true;
            }

            if (HasSecureValues != castedOther.HasSecureValues)
            {
                return true;
            }

            if (HasPassword != castedOther.HasPassword)
            {
                return true;
            }

            if (CurrentAlgo is null && castedOther.CurrentAlgo is not null || CurrentAlgo is not null && castedOther.CurrentAlgo is null)
            {
                return true;
            }

            if (CurrentAlgo is not null && castedOther.CurrentAlgo is not null && CurrentAlgo.Compare(castedOther.CurrentAlgo))
            {
                return true;
            }

            if (SrpB != castedOther.SrpB)
            {
                return true;
            }

            if (SrpId != castedOther.SrpId)
            {
                return true;
            }

            if (Hint != castedOther.Hint)
            {
                return true;
            }

            if (EmailUnconfirmedPattern != castedOther.EmailUnconfirmedPattern)
            {
                return true;
            }

            if (NewAlgo.Compare(castedOther.NewAlgo))
            {
                return true;
            }

            if (NewSecureAlgo.Compare(castedOther.NewSecureAlgo))
            {
                return true;
            }

            if (SecureRandom != castedOther.SecureRandom)
            {
                return true;
            }

            if (PendingResetDate != castedOther.PendingResetDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
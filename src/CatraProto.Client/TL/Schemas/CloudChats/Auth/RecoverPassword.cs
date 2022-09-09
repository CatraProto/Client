using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class RecoverPassword : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NewSettings = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 923364464; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("code")] public string Code { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }


#nullable enable
        public RecoverPassword(string code)
        {
            Code = code;
        }
#nullable disable

        internal RecoverPassword()
        {
        }

        public void UpdateFlags()
        {
            Flags = NewSettings == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Code);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checknewSettings = writer.WriteObject(NewSettings);
                if (checknewSettings.IsError)
                {
                    return checknewSettings;
                }
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trycode = reader.ReadString();
            if (trycode.IsError)
            {
                return ReadResult<IObject>.Move(trycode);
            }

            Code = trycode.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trynewSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();
                if (trynewSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trynewSettings);
                }

                NewSettings = trynewSettings.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.recoverPassword";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RecoverPassword();
            newClonedObject.Flags = Flags;
            newClonedObject.Code = Code;
            if (NewSettings is not null)
            {
                var cloneNewSettings = (CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase?)NewSettings.Clone();
                if (cloneNewSettings is null)
                {
                    return null;
                }

                newClonedObject.NewSettings = cloneNewSettings;
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RecoverPassword castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Code != castedOther.Code)
            {
                return true;
            }

            if (NewSettings is null && castedOther.NewSettings is not null || NewSettings is not null && castedOther.NewSettings is null)
            {
                return true;
            }

            if (NewSettings is not null && castedOther.NewSettings is not null && NewSettings.Compare(castedOther.NewSettings))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
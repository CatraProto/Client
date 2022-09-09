using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class SavedInfo : CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasSavedCredentials = 1 << 1,
            SavedInfoField = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -74456004; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_saved_credentials")]
        public sealed override bool HasSavedCredentials { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_info")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfoField { get; set; }


        public SavedInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HasSavedCredentials ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = SavedInfoField == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checksavedInfoField = writer.WriteObject(SavedInfoField);
                if (checksavedInfoField.IsError)
                {
                    return checksavedInfoField;
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
            HasSavedCredentials = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trysavedInfoField = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (trysavedInfoField.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedInfoField);
                }

                SavedInfoField = trysavedInfoField.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.savedInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedInfo();
            newClonedObject.Flags = Flags;
            newClonedObject.HasSavedCredentials = HasSavedCredentials;
            if (SavedInfoField is not null)
            {
                var cloneSavedInfoField = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)SavedInfoField.Clone();
                if (cloneSavedInfoField is null)
                {
                    return null;
                }

                newClonedObject.SavedInfoField = cloneSavedInfoField;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedInfo castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (HasSavedCredentials != castedOther.HasSavedCredentials)
            {
                return true;
            }

            if (SavedInfoField is null && castedOther.SavedInfoField is not null || SavedInfoField is not null && castedOther.SavedInfoField is null)
            {
                return true;
            }

            if (SavedInfoField is not null && castedOther.SavedInfoField is not null && SavedInfoField.Compare(castedOther.SavedInfoField))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
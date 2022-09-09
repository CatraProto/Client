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
    public partial class ContentSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SensitiveEnabled = 1 << 0,
            SensitiveCanChange = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1474462241; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("sensitive_enabled")]
        public sealed override bool SensitiveEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("sensitive_can_change")]
        public sealed override bool SensitiveCanChange { get; set; }


        public ContentSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SensitiveCanChange ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

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
            SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
            SensitiveCanChange = FlagsHelper.IsFlagSet(Flags, 1);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.contentSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContentSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.SensitiveEnabled = SensitiveEnabled;
            newClonedObject.SensitiveCanChange = SensitiveCanChange;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContentSettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (SensitiveEnabled != castedOther.SensitiveEnabled)
            {
                return true;
            }

            if (SensitiveCanChange != castedOther.SensitiveCanChange)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
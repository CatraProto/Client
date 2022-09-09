using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureRequiredType : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NativeNames = 1 << 0,
            SelfieRequired = 1 << 1,
            TranslationRequired = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2103600678; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("native_names")]
        public bool NativeNames { get; set; }

        [Newtonsoft.Json.JsonProperty("selfie_required")]
        public bool SelfieRequired { get; set; }

        [Newtonsoft.Json.JsonProperty("translation_required")]
        public bool TranslationRequired { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }


#nullable enable
        public SecureRequiredType(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type)
        {
            Type = type;
        }
#nullable disable
        internal SecureRequiredType()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NativeNames ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SelfieRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = TranslationRequired ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
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
            NativeNames = FlagsHelper.IsFlagSet(Flags, 0);
            SelfieRequired = FlagsHelper.IsFlagSet(Flags, 1);
            TranslationRequired = FlagsHelper.IsFlagSet(Flags, 2);
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureRequiredType";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureRequiredType();
            newClonedObject.Flags = Flags;
            newClonedObject.NativeNames = NativeNames;
            newClonedObject.SelfieRequired = SelfieRequired;
            newClonedObject.TranslationRequired = TranslationRequired;
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureRequiredType castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (NativeNames != castedOther.NativeNames)
            {
                return true;
            }

            if (SelfieRequired != castedOther.SelfieRequired)
            {
                return true;
            }

            if (TranslationRequired != castedOther.TranslationRequired)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
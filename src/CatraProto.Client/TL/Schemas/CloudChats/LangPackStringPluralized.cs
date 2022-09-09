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
    public partial class LangPackStringPluralized : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ZeroValue = 1 << 0,
            OneValue = 1 << 1,
            TwoValue = 1 << 2,
            FewValue = 1 << 3,
            ManyValue = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1816636575; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("zero_value")]
        public string ZeroValue { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("one_value")]
        public string OneValue { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("two_value")]
        public string TwoValue { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("few_value")]
        public string FewValue { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("many_value")]
        public string ManyValue { get; set; }

        [Newtonsoft.Json.JsonProperty("other_value")]
        public string OtherValue { get; set; }


#nullable enable
        public LangPackStringPluralized(string key, string otherValue)
        {
            Key = key;
            OtherValue = otherValue;
        }
#nullable disable
        internal LangPackStringPluralized()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ZeroValue == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = OneValue == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = TwoValue == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = FewValue == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = ManyValue == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Key);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(ZeroValue);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(OneValue);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(TwoValue);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(FewValue);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteString(ManyValue);
            }


            writer.WriteString(OtherValue);

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
            var trykey = reader.ReadString();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryzeroValue = reader.ReadString();
                if (tryzeroValue.IsError)
                {
                    return ReadResult<IObject>.Move(tryzeroValue);
                }

                ZeroValue = tryzeroValue.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryoneValue = reader.ReadString();
                if (tryoneValue.IsError)
                {
                    return ReadResult<IObject>.Move(tryoneValue);
                }

                OneValue = tryoneValue.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytwoValue = reader.ReadString();
                if (trytwoValue.IsError)
                {
                    return ReadResult<IObject>.Move(trytwoValue);
                }

                TwoValue = trytwoValue.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryfewValue = reader.ReadString();
                if (tryfewValue.IsError)
                {
                    return ReadResult<IObject>.Move(tryfewValue);
                }

                FewValue = tryfewValue.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trymanyValue = reader.ReadString();
                if (trymanyValue.IsError)
                {
                    return ReadResult<IObject>.Move(trymanyValue);
                }

                ManyValue = trymanyValue.Value;
            }

            var tryotherValue = reader.ReadString();
            if (tryotherValue.IsError)
            {
                return ReadResult<IObject>.Move(tryotherValue);
            }

            OtherValue = tryotherValue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langPackStringPluralized";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LangPackStringPluralized();
            newClonedObject.Flags = Flags;
            newClonedObject.Key = Key;
            newClonedObject.ZeroValue = ZeroValue;
            newClonedObject.OneValue = OneValue;
            newClonedObject.TwoValue = TwoValue;
            newClonedObject.FewValue = FewValue;
            newClonedObject.ManyValue = ManyValue;
            newClonedObject.OtherValue = OtherValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LangPackStringPluralized castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Key != castedOther.Key)
            {
                return true;
            }

            if (ZeroValue != castedOther.ZeroValue)
            {
                return true;
            }

            if (OneValue != castedOther.OneValue)
            {
                return true;
            }

            if (TwoValue != castedOther.TwoValue)
            {
                return true;
            }

            if (FewValue != castedOther.FewValue)
            {
                return true;
            }

            if (ManyValue != castedOther.ManyValue)
            {
                return true;
            }

            if (OtherValue != castedOther.OtherValue)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
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
    public partial class SetContentSettings : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            SensitiveEnabled = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1250643605; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("sensitive_enabled")]
        public bool SensitiveEnabled { get; set; }


        public SetContentSettings()
        {
        }

        public void UpdateFlags()
        {
            Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

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
            SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.setContentSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetContentSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.SensitiveEnabled = SensitiveEnabled;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetContentSettings castedOther)
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

            return false;
        }
#nullable disable
    }
}
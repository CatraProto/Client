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
    public partial class ClearSavedInfo : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Credentials = 1 << 0,
            Info = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -667062079; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public bool Credentials { get; set; }

        [Newtonsoft.Json.JsonProperty("info")] public bool Info { get; set; }


        public ClearSavedInfo()
        {
        }

        public void UpdateFlags()
        {
            Flags = Credentials ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Info ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
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
            Credentials = FlagsHelper.IsFlagSet(Flags, 0);
            Info = FlagsHelper.IsFlagSet(Flags, 1);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.clearSavedInfo";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ClearSavedInfo();
            newClonedObject.Flags = Flags;
            newClonedObject.Credentials = Credentials;
            newClonedObject.Info = Info;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ClearSavedInfo castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Credentials != castedOther.Credentials)
            {
                return true;
            }

            if (Info != castedOther.Info)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
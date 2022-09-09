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
    public partial class FinishTakeoutSession : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Success = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 489050862; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success { get; set; }


        public FinishTakeoutSession()
        {
        }

        public void UpdateFlags()
        {
            Flags = Success ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            Success = FlagsHelper.IsFlagSet(Flags, 0);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.finishTakeoutSession";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new FinishTakeoutSession();
            newClonedObject.Flags = Flags;
            newClonedObject.Success = Success;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not FinishTakeoutSession castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Success != castedOther.Success)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
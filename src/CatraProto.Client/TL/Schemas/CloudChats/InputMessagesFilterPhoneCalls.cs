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
    public partial class InputMessagesFilterPhoneCalls : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Missed = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2134272152; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("missed")]
        public bool Missed { get; set; }


        public InputMessagesFilterPhoneCalls()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Missed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            Missed = FlagsHelper.IsFlagSet(Flags, 0);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMessagesFilterPhoneCalls";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessagesFilterPhoneCalls();
            newClonedObject.Flags = Flags;
            newClonedObject.Missed = Missed;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMessagesFilterPhoneCalls castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Missed != castedOther.Missed)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
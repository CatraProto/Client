using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeletePhoneCallHistory : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoke = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -104078327; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke")]
        public bool Revoke { get; set; }


        public DeletePhoneCallHistory()
        {
        }

        public void UpdateFlags()
        {
            Flags = Revoke ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            Revoke = FlagsHelper.IsFlagSet(Flags, 0);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.deletePhoneCallHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeletePhoneCallHistory();
            newClonedObject.Flags = Flags;
            newClonedObject.Revoke = Revoke;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeletePhoneCallHistory castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Revoke != castedOther.Revoke)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
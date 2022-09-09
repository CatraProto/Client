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
    public partial class AssignAppStoreTransaction : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Restore = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 224186320; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("restore")]
        public bool Restore { get; set; }

        [Newtonsoft.Json.JsonProperty("receipt")]
        public byte[] Receipt { get; set; }


#nullable enable
        public AssignAppStoreTransaction(byte[] receipt)
        {
            Receipt = receipt;
        }
#nullable disable

        internal AssignAppStoreTransaction()
        {
        }

        public void UpdateFlags()
        {
            Flags = Restore ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteBytes(Receipt);

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
            Restore = FlagsHelper.IsFlagSet(Flags, 0);
            var tryreceipt = reader.ReadBytes();
            if (tryreceipt.IsError)
            {
                return ReadResult<IObject>.Move(tryreceipt);
            }

            Receipt = tryreceipt.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.assignAppStoreTransaction";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AssignAppStoreTransaction();
            newClonedObject.Flags = Flags;
            newClonedObject.Restore = Restore;
            newClonedObject.Receipt = Receipt;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AssignAppStoreTransaction castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Restore != castedOther.Restore)
            {
                return true;
            }

            if (Receipt != castedOther.Receipt)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
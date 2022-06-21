/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 224186320; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
            var newClonedObject = new AssignAppStoreTransaction
            {
                Flags = Flags,
                Restore = Restore,
                Receipt = Receipt
            };
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
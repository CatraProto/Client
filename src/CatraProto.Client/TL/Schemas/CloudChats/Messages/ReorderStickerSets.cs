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
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReorderStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2016638777; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("order")]
        public List<long> Order { get; set; }


#nullable enable
        public ReorderStickerSets(List<long> order)
        {
            Order = order;

        }
#nullable disable

        internal ReorderStickerSets()
        {
        }

        public void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteVector(Order, false);

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
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            var tryorder = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryorder.IsError)
            {
                return ReadResult<IObject>.Move(tryorder);
            }
            Order = tryorder.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.reorderStickerSets";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReorderStickerSets
            {
                Flags = Flags,
                Masks = Masks,
                Order = new List<long>()
            };
            foreach (var order in Order)
            {
                newClonedObject.Order.Add(order);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ReorderStickerSets castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Masks != castedOther.Masks)
            {
                return true;
            }
            var ordersize = castedOther.Order.Count;
            if (ordersize != Order.Count)
            {
                return true;
            }
            for (var i = 0; i < ordersize; i++)
            {
                if (castedOther.Order[i] != Order[i])
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}
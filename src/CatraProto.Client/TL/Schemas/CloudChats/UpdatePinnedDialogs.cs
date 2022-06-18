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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePinnedDialogs : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 1,
            Order = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -99664734; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("order")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase> Order { get; set; }



        public UpdatePinnedDialogs()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Order == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(FolderId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkorder = writer.WriteVector(Order, false);
                if (checkorder.IsError)
                {
                    return checkorder;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }
                FolderId = tryfolderId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryorder = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryorder.IsError)
                {
                    return ReadResult<IObject>.Move(tryorder);
                }
                Order = tryorder.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePinnedDialogs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePinnedDialogs
            {
                Flags = Flags,
                FolderId = FolderId
            };
            if (Order is not null)
            {
                newClonedObject.Order = new List<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
                foreach (var order in Order)
                {
                    var cloneorder = (CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase?)order.Clone();
                    if (cloneorder is null)
                    {
                        return null;
                    }
                    newClonedObject.Order.Add(cloneorder);
                }
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePinnedDialogs castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (FolderId != castedOther.FolderId)
            {
                return true;
            }
            if (Order is null && castedOther.Order is not null || Order is not null && castedOther.Order is null)
            {
                return true;
            }
            if (Order is not null && castedOther.Order is not null)
            {

                var ordersize = castedOther.Order.Count;
                if (ordersize != Order.Count)
                {
                    return true;
                }
                for (var i = 0; i < ordersize; i++)
                {
                    if (castedOther.Order[i].Compare(Order[i]))
                    {
                        return true;
                    }
                }
            }
            return false;

        }

#nullable disable
    }
}
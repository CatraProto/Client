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
    public partial class ReorderPinnedDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Force = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 991616823; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("force")]
        public bool Force { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("order")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Order { get; set; }


#nullable enable
        public ReorderPinnedDialogs(int folderId, List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> order)
        {
            FolderId = folderId;
            Order = order;

        }
#nullable disable

        internal ReorderPinnedDialogs()
        {
        }

        public void UpdateFlags()
        {
            Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(FolderId);
            var checkorder = writer.WriteVector(Order, false);
            if (checkorder.IsError)
            {
                return checkorder;
            }

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
            Force = FlagsHelper.IsFlagSet(Flags, 0);
            var tryfolderId = reader.ReadInt32();
            if (tryfolderId.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderId);
            }
            FolderId = tryfolderId.Value;
            var tryorder = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryorder.IsError)
            {
                return ReadResult<IObject>.Move(tryorder);
            }
            Order = tryorder.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.reorderPinnedDialogs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReorderPinnedDialogs
            {
                Flags = Flags,
                Force = Force,
                FolderId = FolderId,
                Order = new List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>()
            };
            foreach (var order in Order)
            {
                var cloneorder = (CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase?)order.Clone();
                if (cloneorder is null)
                {
                    return null;
                }
                newClonedObject.Order.Add(cloneorder);
            }
            return newClonedObject;

        }
#nullable disable
    }
}
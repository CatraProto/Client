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
    public partial class ReorderPinnedDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Force = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 991616823; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

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
            var newClonedObject = new ReorderPinnedDialogs();
            newClonedObject.Flags = Flags;
            newClonedObject.Force = Force;
            newClonedObject.FolderId = FolderId;
            newClonedObject.Order = new List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();
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

        public bool Compare(IObject other)
        {
            if (other is not ReorderPinnedDialogs castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Force != castedOther.Force)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
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
                if (castedOther.Order[i].Compare(Order[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}
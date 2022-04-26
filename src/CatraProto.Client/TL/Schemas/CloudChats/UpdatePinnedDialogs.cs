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
#nullable disable
    }
}
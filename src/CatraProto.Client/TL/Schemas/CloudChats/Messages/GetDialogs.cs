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
    public partial class GetDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ExcludePinned = 1 << 0,
            FolderId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1594569905; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_pinned")]
        public bool ExcludePinned { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_date")]
        public int OffsetDate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


#nullable enable
        public GetDialogs(int offsetDate, int offsetId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int limit, long hash)
        {
            OffsetDate = offsetDate;
            OffsetId = offsetId;
            OffsetPeer = offsetPeer;
            Limit = limit;
            Hash = hash;
        }
#nullable disable

        internal GetDialogs()
        {
        }

        public void UpdateFlags()
        {
            Flags = ExcludePinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(FolderId.Value);
            }

            writer.WriteInt32(OffsetDate);
            writer.WriteInt32(OffsetId);
            var checkoffsetPeer = writer.WriteObject(OffsetPeer);
            if (checkoffsetPeer.IsError)
            {
                return checkoffsetPeer;
            }

            writer.WriteInt32(Limit);
            writer.WriteInt64(Hash);

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
            ExcludePinned = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

            var tryoffsetDate = reader.ReadInt32();
            if (tryoffsetDate.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetDate);
            }

            OffsetDate = tryoffsetDate.Value;
            var tryoffsetId = reader.ReadInt32();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }

            OffsetId = tryoffsetId.Value;
            var tryoffsetPeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryoffsetPeer.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetPeer);
            }

            OffsetPeer = tryoffsetPeer.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getDialogs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDialogs();
            newClonedObject.Flags = Flags;
            newClonedObject.ExcludePinned = ExcludePinned;
            newClonedObject.FolderId = FolderId;
            newClonedObject.OffsetDate = OffsetDate;
            newClonedObject.OffsetId = OffsetId;
            var cloneOffsetPeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)OffsetPeer.Clone();
            if (cloneOffsetPeer is null)
            {
                return null;
            }

            newClonedObject.OffsetPeer = cloneOffsetPeer;
            newClonedObject.Limit = Limit;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetDialogs castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ExcludePinned != castedOther.ExcludePinned)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            if (OffsetDate != castedOther.OffsetDate)
            {
                return true;
            }

            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }

            if (OffsetPeer.Compare(castedOther.OffsetPeer))
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
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
    public partial class GetExportedChatInvites : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoked = 1 << 3,
            OffsetDate = 1 << 2,
            OffsetLink = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1565154314; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoked")]
        public bool Revoked { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_date")]
        public int? OffsetDate { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("offset_link")]
        public string OffsetLink { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetExportedChatInvites(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase adminId, int limit)
        {
            Peer = peer;
            AdminId = adminId;
            Limit = limit;
        }
#nullable disable

        internal GetExportedChatInvites()
        {
        }

        public void UpdateFlags()
        {
            Flags = Revoked ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = OffsetDate == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = OffsetLink == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            var checkadminId = writer.WriteObject(AdminId);
            if (checkadminId.IsError)
            {
                return checkadminId;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(OffsetDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(OffsetLink);
            }

            writer.WriteInt32(Limit);

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
            Revoked = FlagsHelper.IsFlagSet(Flags, 3);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryadminId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryadminId.IsError)
            {
                return ReadResult<IObject>.Move(tryadminId);
            }

            AdminId = tryadminId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryoffsetDate = reader.ReadInt32();
                if (tryoffsetDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryoffsetDate);
                }

                OffsetDate = tryoffsetDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryoffsetLink = reader.ReadString();
                if (tryoffsetLink.IsError)
                {
                    return ReadResult<IObject>.Move(tryoffsetLink);
                }

                OffsetLink = tryoffsetLink.Value;
            }

            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getExportedChatInvites";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetExportedChatInvites();
            newClonedObject.Flags = Flags;
            newClonedObject.Revoked = Revoked;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneAdminId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)AdminId.Clone();
            if (cloneAdminId is null)
            {
                return null;
            }

            newClonedObject.AdminId = cloneAdminId;
            newClonedObject.OffsetDate = OffsetDate;
            newClonedObject.OffsetLink = OffsetLink;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetExportedChatInvites castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Revoked != castedOther.Revoked)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (AdminId.Compare(castedOther.AdminId))
            {
                return true;
            }

            if (OffsetDate != castedOther.OffsetDate)
            {
                return true;
            }

            if (OffsetLink != castedOther.OffsetLink)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
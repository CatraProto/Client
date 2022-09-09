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
    public partial class GetChatInviteImporters : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Requested = 1 << 0,
            Link = 1 << 1,
            Q = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -553329330; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public bool Requested { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("link")]
        public string Link { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("q")]
        public string Q { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_date")]
        public int OffsetDate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_user")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase OffsetUser { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetChatInviteImporters(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetDate, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase offsetUser, int limit)
        {
            Peer = peer;
            OffsetDate = offsetDate;
            OffsetUser = offsetUser;
            Limit = limit;
        }
#nullable disable

        internal GetChatInviteImporters()
        {
        }

        public void UpdateFlags()
        {
            Flags = Requested ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Link == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Q == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
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

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Link);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Q);
            }

            writer.WriteInt32(OffsetDate);
            var checkoffsetUser = writer.WriteObject(OffsetUser);
            if (checkoffsetUser.IsError)
            {
                return checkoffsetUser;
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
            Requested = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trylink = reader.ReadString();
                if (trylink.IsError)
                {
                    return ReadResult<IObject>.Move(trylink);
                }

                Link = trylink.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryq = reader.ReadString();
                if (tryq.IsError)
                {
                    return ReadResult<IObject>.Move(tryq);
                }

                Q = tryq.Value;
            }

            var tryoffsetDate = reader.ReadInt32();
            if (tryoffsetDate.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetDate);
            }

            OffsetDate = tryoffsetDate.Value;
            var tryoffsetUser = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryoffsetUser.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetUser);
            }

            OffsetUser = tryoffsetUser.Value;
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
            return "messages.getChatInviteImporters";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetChatInviteImporters();
            newClonedObject.Flags = Flags;
            newClonedObject.Requested = Requested;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Link = Link;
            newClonedObject.Q = Q;
            newClonedObject.OffsetDate = OffsetDate;
            var cloneOffsetUser = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)OffsetUser.Clone();
            if (cloneOffsetUser is null)
            {
                return null;
            }

            newClonedObject.OffsetUser = cloneOffsetUser;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetChatInviteImporters castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Requested != castedOther.Requested)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Link != castedOther.Link)
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            if (OffsetDate != castedOther.OffsetDate)
            {
                return true;
            }

            if (OffsetUser.Compare(castedOther.OffsetUser))
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
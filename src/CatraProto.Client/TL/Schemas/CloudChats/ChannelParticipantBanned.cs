using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantBanned : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Left = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1844969806; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("left")] public bool Left { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("kicked_by")]
        public long KickedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }


#nullable enable
        public ChannelParticipantBanned(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, long kickedBy, int date, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights)
        {
            Peer = peer;
            KickedBy = kickedBy;
            Date = date;
            BannedRights = bannedRights;
        }
#nullable disable
        internal ChannelParticipantBanned()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Left ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(KickedBy);
            writer.WriteInt32(Date);
            var checkbannedRights = writer.WriteObject(BannedRights);
            if (checkbannedRights.IsError)
            {
                return checkbannedRights;
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
            Left = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trykickedBy = reader.ReadInt64();
            if (trykickedBy.IsError)
            {
                return ReadResult<IObject>.Move(trykickedBy);
            }

            KickedBy = trykickedBy.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var trybannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
            if (trybannedRights.IsError)
            {
                return ReadResult<IObject>.Move(trybannedRights);
            }

            BannedRights = trybannedRights.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantBanned";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantBanned();
            newClonedObject.Flags = Flags;
            newClonedObject.Left = Left;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.KickedBy = KickedBy;
            newClonedObject.Date = Date;
            var cloneBannedRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase?)BannedRights.Clone();
            if (cloneBannedRights is null)
            {
                return null;
            }

            newClonedObject.BannedRights = cloneBannedRights;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantBanned castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Left != castedOther.Left)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (KickedBy != castedOther.KickedBy)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (BannedRights.Compare(castedOther.BannedRights))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
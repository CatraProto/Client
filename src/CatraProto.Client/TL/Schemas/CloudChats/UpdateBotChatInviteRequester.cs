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
    public partial class UpdateBotChatInviteRequester : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 299870598; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public UpdateBotChatInviteRequester(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int date, long userId, string about, CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, int qts)
        {
            Peer = peer;
            Date = date;
            UserId = userId;
            About = about;
            Invite = invite;
            Qts = qts;
        }
#nullable disable
        internal UpdateBotChatInviteRequester()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Date);
            writer.WriteInt64(UserId);

            writer.WriteString(About);
            var checkinvite = writer.WriteObject(Invite);
            if (checkinvite.IsError)
            {
                return checkinvite;
            }

            writer.WriteInt32(Qts);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryabout = reader.ReadString();
            if (tryabout.IsError)
            {
                return ReadResult<IObject>.Move(tryabout);
            }

            About = tryabout.Value;
            var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryinvite.IsError)
            {
                return ReadResult<IObject>.Move(tryinvite);
            }

            Invite = tryinvite.Value;
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateBotChatInviteRequester";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotChatInviteRequester();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Date = Date;
            newClonedObject.UserId = UserId;
            newClonedObject.About = About;
            var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
            if (cloneInvite is null)
            {
                return null;
            }

            newClonedObject.Invite = cloneInvite;
            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotChatInviteRequester castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (Invite.Compare(castedOther.Invite))
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
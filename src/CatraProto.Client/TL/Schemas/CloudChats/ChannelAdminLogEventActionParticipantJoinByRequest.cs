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
    public partial class ChannelAdminLogEventActionParticipantJoinByRequest : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1347021750; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("approved_by")]
        public long ApprovedBy { get; set; }


#nullable enable
        public ChannelAdminLogEventActionParticipantJoinByRequest(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, long approvedBy)
        {
            Invite = invite;
            ApprovedBy = approvedBy;
        }
#nullable disable
        internal ChannelAdminLogEventActionParticipantJoinByRequest()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkinvite = writer.WriteObject(Invite);
            if (checkinvite.IsError)
            {
                return checkinvite;
            }

            writer.WriteInt64(ApprovedBy);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryinvite.IsError)
            {
                return ReadResult<IObject>.Move(tryinvite);
            }

            Invite = tryinvite.Value;
            var tryapprovedBy = reader.ReadInt64();
            if (tryapprovedBy.IsError)
            {
                return ReadResult<IObject>.Move(tryapprovedBy);
            }

            ApprovedBy = tryapprovedBy.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantJoinByRequest";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionParticipantJoinByRequest();
            var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
            if (cloneInvite is null)
            {
                return null;
            }

            newClonedObject.Invite = cloneInvite;
            newClonedObject.ApprovedBy = ApprovedBy;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionParticipantJoinByRequest castedOther)
            {
                return true;
            }

            if (Invite.Compare(castedOther.Invite))
            {
                return true;
            }

            if (ApprovedBy != castedOther.ApprovedBy)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
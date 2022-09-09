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
    public partial class ChannelAdminLogEventActionExportedInviteDelete : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1515256996; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }


#nullable enable
        public ChannelAdminLogEventActionExportedInviteDelete(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite)
        {
            Invite = invite;
        }
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteDelete()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionExportedInviteDelete";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionExportedInviteDelete();
            var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
            if (cloneInvite is null)
            {
                return null;
            }

            newClonedObject.Invite = cloneInvite;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionExportedInviteDelete castedOther)
            {
                return true;
            }

            if (Invite.Compare(castedOther.Invite))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
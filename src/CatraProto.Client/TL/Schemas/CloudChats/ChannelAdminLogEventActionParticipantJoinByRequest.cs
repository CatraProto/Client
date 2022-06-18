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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionParticipantJoinByRequest : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1347021750; }

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
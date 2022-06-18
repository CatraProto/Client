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
    public partial class ChannelAdminLogEventActionExportedInviteEdit : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -384910503; }

        [Newtonsoft.Json.JsonProperty("prev_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase PrevInvite { get; set; }

        [Newtonsoft.Json.JsonProperty("new_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase NewInvite { get; set; }


#nullable enable
        public ChannelAdminLogEventActionExportedInviteEdit(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase prevInvite, CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase newInvite)
        {
            PrevInvite = prevInvite;
            NewInvite = newInvite;

        }
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteEdit()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevInvite = writer.WriteObject(PrevInvite);
            if (checkprevInvite.IsError)
            {
                return checkprevInvite;
            }
            var checknewInvite = writer.WriteObject(NewInvite);
            if (checknewInvite.IsError)
            {
                return checknewInvite;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryprevInvite.IsError)
            {
                return ReadResult<IObject>.Move(tryprevInvite);
            }
            PrevInvite = tryprevInvite.Value;
            var trynewInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (trynewInvite.IsError)
            {
                return ReadResult<IObject>.Move(trynewInvite);
            }
            NewInvite = trynewInvite.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionExportedInviteEdit";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionExportedInviteEdit();
            var clonePrevInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)PrevInvite.Clone();
            if (clonePrevInvite is null)
            {
                return null;
            }
            newClonedObject.PrevInvite = clonePrevInvite;
            var cloneNewInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)NewInvite.Clone();
            if (cloneNewInvite is null)
            {
                return null;
            }
            newClonedObject.NewInvite = cloneNewInvite;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionExportedInviteEdit castedOther)
            {
                return true;
            }
            if (PrevInvite.Compare(castedOther.PrevInvite))
            {
                return true;
            }
            if (NewInvite.Compare(castedOther.NewInvite))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
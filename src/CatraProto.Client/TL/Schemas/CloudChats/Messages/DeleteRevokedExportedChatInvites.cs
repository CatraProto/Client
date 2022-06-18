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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteRevokedExportedChatInvites : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1452833749; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase AdminId { get; set; }


#nullable enable
        public DeleteRevokedExportedChatInvites(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase adminId)
        {
            Peer = peer;
            AdminId = adminId;

        }
#nullable disable

        internal DeleteRevokedExportedChatInvites()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
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

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.deleteRevokedExportedChatInvites";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteRevokedExportedChatInvites();
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
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteRevokedExportedChatInvites castedOther)
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
            return false;

        }
#nullable disable
    }
}
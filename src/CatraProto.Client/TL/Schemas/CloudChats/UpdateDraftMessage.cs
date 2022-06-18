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
    public partial class UpdateDraftMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -299124375; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("draft")]
        public CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase Draft { get; set; }


#nullable enable
        public UpdateDraftMessage(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase draft)
        {
            Peer = peer;
            Draft = draft;

        }
#nullable disable
        internal UpdateDraftMessage()
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
            var checkdraft = writer.WriteObject(Draft);
            if (checkdraft.IsError)
            {
                return checkdraft;
            }

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
            var trydraft = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase>();
            if (trydraft.IsError)
            {
                return ReadResult<IObject>.Move(trydraft);
            }
            Draft = trydraft.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateDraftMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDraftMessage();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            var cloneDraft = (CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase?)Draft.Clone();
            if (cloneDraft is null)
            {
                return null;
            }
            newClonedObject.Draft = cloneDraft;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateDraftMessage castedOther)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            if (Draft.Compare(castedOther.Draft))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
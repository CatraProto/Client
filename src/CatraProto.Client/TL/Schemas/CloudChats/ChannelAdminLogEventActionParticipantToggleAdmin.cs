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
    public partial class ChannelAdminLogEventActionParticipantToggleAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -714643696; }

        [Newtonsoft.Json.JsonProperty("prev_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

        [Newtonsoft.Json.JsonProperty("new_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }


#nullable enable
        public ChannelAdminLogEventActionParticipantToggleAdmin(CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase prevParticipant, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase newParticipant)
        {
            PrevParticipant = prevParticipant;
            NewParticipant = newParticipant;

        }
#nullable disable
        internal ChannelAdminLogEventActionParticipantToggleAdmin()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevParticipant = writer.WriteObject(PrevParticipant);
            if (checkprevParticipant.IsError)
            {
                return checkprevParticipant;
            }
            var checknewParticipant = writer.WriteObject(NewParticipant);
            if (checknewParticipant.IsError)
            {
                return checknewParticipant;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
            if (tryprevParticipant.IsError)
            {
                return ReadResult<IObject>.Move(tryprevParticipant);
            }
            PrevParticipant = tryprevParticipant.Value;
            var trynewParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
            if (trynewParticipant.IsError)
            {
                return ReadResult<IObject>.Move(trynewParticipant);
            }
            NewParticipant = trynewParticipant.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantToggleAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionParticipantToggleAdmin();
            var clonePrevParticipant = (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase?)PrevParticipant.Clone();
            if (clonePrevParticipant is null)
            {
                return null;
            }
            newClonedObject.PrevParticipant = clonePrevParticipant;
            var cloneNewParticipant = (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase?)NewParticipant.Clone();
            if (cloneNewParticipant is null)
            {
                return null;
            }
            newClonedObject.NewParticipant = cloneNewParticipant;
            return newClonedObject;

        }
#nullable disable
    }
}
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
    public partial class ChannelAdminLogEventActionDefaultBannedRights : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 771095562; }

        [Newtonsoft.Json.JsonProperty("prev_banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase PrevBannedRights { get; set; }

        [Newtonsoft.Json.JsonProperty("new_banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase NewBannedRights { get; set; }


#nullable enable
        public ChannelAdminLogEventActionDefaultBannedRights(CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase prevBannedRights, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase newBannedRights)
        {
            PrevBannedRights = prevBannedRights;
            NewBannedRights = newBannedRights;

        }
#nullable disable
        internal ChannelAdminLogEventActionDefaultBannedRights()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevBannedRights = writer.WriteObject(PrevBannedRights);
            if (checkprevBannedRights.IsError)
            {
                return checkprevBannedRights;
            }
            var checknewBannedRights = writer.WriteObject(NewBannedRights);
            if (checknewBannedRights.IsError)
            {
                return checknewBannedRights;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevBannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
            if (tryprevBannedRights.IsError)
            {
                return ReadResult<IObject>.Move(tryprevBannedRights);
            }
            PrevBannedRights = tryprevBannedRights.Value;
            var trynewBannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
            if (trynewBannedRights.IsError)
            {
                return ReadResult<IObject>.Move(trynewBannedRights);
            }
            NewBannedRights = trynewBannedRights.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionDefaultBannedRights";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionDefaultBannedRights();
            var clonePrevBannedRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase?)PrevBannedRights.Clone();
            if (clonePrevBannedRights is null)
            {
                return null;
            }
            newClonedObject.PrevBannedRights = clonePrevBannedRights;
            var cloneNewBannedRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase?)NewBannedRights.Clone();
            if (cloneNewBannedRights is null)
            {
                return null;
            }
            newClonedObject.NewBannedRights = cloneNewBannedRights;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionDefaultBannedRights castedOther)
            {
                return true;
            }
            if (PrevBannedRights.Compare(castedOther.PrevBannedRights))
            {
                return true;
            }
            if (NewBannedRights.Compare(castedOther.NewBannedRights))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
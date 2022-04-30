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
    public partial class ChannelAdminLogEventActionChangeLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 241923758; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeLocation(CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase prevValue, CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangeLocation()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevValue = writer.WriteObject(PrevValue);
            if (checkprevValue.IsError)
            {
                return checkprevValue;
            }
            var checknewValue = writer.WriteObject(NewValue);
            if (checknewValue.IsError)
            {
                return checknewValue;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }
            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }
            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeLocation();
            var clonePrevValue = (CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase?)PrevValue.Clone();
            if (clonePrevValue is null)
            {
                return null;
            }
            newClonedObject.PrevValue = clonePrevValue;
            var cloneNewValue = (CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase?)NewValue.Clone();
            if (cloneNewValue is null)
            {
                return null;
            }
            newClonedObject.NewValue = cloneNewValue;
            return newClonedObject;

        }
#nullable disable
    }
}
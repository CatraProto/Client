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
    public partial class MessageActionGeoProximityReached : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1730095465; }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("to_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase ToId { get; set; }

        [Newtonsoft.Json.JsonProperty("distance")]
        public int Distance { get; set; }


#nullable enable
        public MessageActionGeoProximityReached(CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId, CatraProto.Client.TL.Schemas.CloudChats.PeerBase toId, int distance)
        {
            FromId = fromId;
            ToId = toId;
            Distance = distance;

        }
#nullable disable
        internal MessageActionGeoProximityReached()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfromId = writer.WriteObject(FromId);
            if (checkfromId.IsError)
            {
                return checkfromId;
            }
            var checktoId = writer.WriteObject(ToId);
            if (checktoId.IsError)
            {
                return checktoId;
            }
            writer.WriteInt32(Distance);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (tryfromId.IsError)
            {
                return ReadResult<IObject>.Move(tryfromId);
            }
            FromId = tryfromId.Value;
            var trytoId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trytoId.IsError)
            {
                return ReadResult<IObject>.Move(trytoId);
            }
            ToId = trytoId.Value;
            var trydistance = reader.ReadInt32();
            if (trydistance.IsError)
            {
                return ReadResult<IObject>.Move(trydistance);
            }
            Distance = trydistance.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionGeoProximityReached";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionGeoProximityReached();
            var cloneFromId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)FromId.Clone();
            if (cloneFromId is null)
            {
                return null;
            }
            newClonedObject.FromId = cloneFromId;
            var cloneToId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)ToId.Clone();
            if (cloneToId is null)
            {
                return null;
            }
            newClonedObject.ToId = cloneToId;
            newClonedObject.Distance = Distance;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionGeoProximityReached castedOther)
            {
                return true;
            }
            if (FromId.Compare(castedOther.FromId))
            {
                return true;
            }
            if (ToId.Compare(castedOther.ToId))
            {
                return true;
            }
            if (Distance != castedOther.Distance)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
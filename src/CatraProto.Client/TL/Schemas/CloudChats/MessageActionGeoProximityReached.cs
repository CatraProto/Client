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
    public partial class MessageActionGeoProximityReached : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1730095465; }

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
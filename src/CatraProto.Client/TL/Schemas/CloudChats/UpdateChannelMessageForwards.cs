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
    public partial class UpdateChannelMessageForwards : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -761649164; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public int Forwards { get; set; }


#nullable enable
        public UpdateChannelMessageForwards(long channelId, int id, int forwards)
        {
            ChannelId = channelId;
            Id = id;
            Forwards = forwards;
        }
#nullable disable
        internal UpdateChannelMessageForwards()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);
            writer.WriteInt32(Id);
            writer.WriteInt32(Forwards);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }

            ChannelId = trychannelId.Value;
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryforwards = reader.ReadInt32();
            if (tryforwards.IsError)
            {
                return ReadResult<IObject>.Move(tryforwards);
            }

            Forwards = tryforwards.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelMessageForwards";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelMessageForwards();
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.Id = Id;
            newClonedObject.Forwards = Forwards;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelMessageForwards castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Forwards != castedOther.Forwards)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
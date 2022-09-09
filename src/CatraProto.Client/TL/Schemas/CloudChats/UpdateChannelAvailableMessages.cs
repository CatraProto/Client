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
    public partial class UpdateChannelAvailableMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1304443240; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("available_min_id")]
        public int AvailableMinId { get; set; }


#nullable enable
        public UpdateChannelAvailableMessages(long channelId, int availableMinId)
        {
            ChannelId = channelId;
            AvailableMinId = availableMinId;
        }
#nullable disable
        internal UpdateChannelAvailableMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);
            writer.WriteInt32(AvailableMinId);

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
            var tryavailableMinId = reader.ReadInt32();
            if (tryavailableMinId.IsError)
            {
                return ReadResult<IObject>.Move(tryavailableMinId);
            }

            AvailableMinId = tryavailableMinId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelAvailableMessages";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelAvailableMessages();
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.AvailableMinId = AvailableMinId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelAvailableMessages castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (AvailableMinId != castedOther.AvailableMinId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
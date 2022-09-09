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
    public partial class UpdateReadChannelDiscussionOutbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1767677564; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int TopMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public int ReadMaxId { get; set; }


#nullable enable
        public UpdateReadChannelDiscussionOutbox(long channelId, int topMsgId, int readMaxId)
        {
            ChannelId = channelId;
            TopMsgId = topMsgId;
            ReadMaxId = readMaxId;
        }
#nullable disable
        internal UpdateReadChannelDiscussionOutbox()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);
            writer.WriteInt32(TopMsgId);
            writer.WriteInt32(ReadMaxId);

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
            var trytopMsgId = reader.ReadInt32();
            if (trytopMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trytopMsgId);
            }

            TopMsgId = trytopMsgId.Value;
            var tryreadMaxId = reader.ReadInt32();
            if (tryreadMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadMaxId);
            }

            ReadMaxId = tryreadMaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateReadChannelDiscussionOutbox";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateReadChannelDiscussionOutbox();
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.TopMsgId = TopMsgId;
            newClonedObject.ReadMaxId = ReadMaxId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateReadChannelDiscussionOutbox castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }

            if (ReadMaxId != castedOther.ReadMaxId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
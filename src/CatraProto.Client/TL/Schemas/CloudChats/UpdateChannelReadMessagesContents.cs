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
    public partial class UpdateChannelReadMessagesContents : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1153291573; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public List<int> Messages { get; set; }


#nullable enable
        public UpdateChannelReadMessagesContents(long channelId, List<int> messages)
        {
            ChannelId = channelId;
            Messages = messages;
        }
#nullable disable
        internal UpdateChannelReadMessagesContents()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);

            writer.WriteVector(Messages, false);

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
            var trymessages = reader.ReadVector<int>(ParserTypes.Int);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }

            Messages = trymessages.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelReadMessagesContents";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelReadMessagesContents();
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.Messages = new List<int>();
            foreach (var messages in Messages)
            {
                newClonedObject.Messages.Add(messages);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelReadMessagesContents castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            var messagessize = castedOther.Messages.Count;
            if (messagessize != Messages.Count)
            {
                return true;
            }

            for (var i = 0; i < messagessize; i++)
            {
                if (castedOther.Messages[i] != Messages[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}
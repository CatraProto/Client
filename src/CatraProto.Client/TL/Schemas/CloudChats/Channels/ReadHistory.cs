using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ReadHistory : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -871347913; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


#nullable enable
        public ReadHistory(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId)
        {
            Channel = channel;
            MaxId = maxId;
        }
#nullable disable

        internal ReadHistory()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            writer.WriteInt32(MaxId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.readHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReadHistory();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.MaxId = MaxId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReadHistory castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
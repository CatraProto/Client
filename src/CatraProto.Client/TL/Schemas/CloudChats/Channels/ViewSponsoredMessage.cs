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
    public partial class ViewSponsoredMessage : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1095836780; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public byte[] RandomId { get; set; }


#nullable enable
        public ViewSponsoredMessage(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, byte[] randomId)
        {
            Channel = channel;
            RandomId = randomId;
        }
#nullable disable

        internal ViewSponsoredMessage()
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

            writer.WriteBytes(RandomId);

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
            var tryrandomId = reader.ReadBytes();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.viewSponsoredMessage";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ViewSponsoredMessage();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.RandomId = RandomId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ViewSponsoredMessage castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
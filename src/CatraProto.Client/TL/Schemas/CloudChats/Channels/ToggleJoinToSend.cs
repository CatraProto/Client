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
    public partial class ToggleJoinToSend : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -456419968; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled")]
        public bool Enabled { get; set; }


#nullable enable
        public ToggleJoinToSend(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled)
        {
            Channel = channel;
            Enabled = enabled;
        }
#nullable disable

        internal ToggleJoinToSend()
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

            var checkenabled = writer.WriteBool(Enabled);
            if (checkenabled.IsError)
            {
                return checkenabled;
            }

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
            var tryenabled = reader.ReadBool();
            if (tryenabled.IsError)
            {
                return ReadResult<IObject>.Move(tryenabled);
            }

            Enabled = tryenabled.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.toggleJoinToSend";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleJoinToSend();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.Enabled = Enabled;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleJoinToSend castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (Enabled != castedOther.Enabled)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
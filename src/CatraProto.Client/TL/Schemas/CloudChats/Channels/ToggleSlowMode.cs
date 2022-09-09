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
    public partial class ToggleSlowMode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -304832784; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("seconds")]
        public int Seconds { get; set; }


#nullable enable
        public ToggleSlowMode(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int seconds)
        {
            Channel = channel;
            Seconds = seconds;
        }
#nullable disable

        internal ToggleSlowMode()
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

            writer.WriteInt32(Seconds);

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
            var tryseconds = reader.ReadInt32();
            if (tryseconds.IsError)
            {
                return ReadResult<IObject>.Move(tryseconds);
            }

            Seconds = tryseconds.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.toggleSlowMode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleSlowMode();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.Seconds = Seconds;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleSlowMode castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (Seconds != castedOther.Seconds)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}
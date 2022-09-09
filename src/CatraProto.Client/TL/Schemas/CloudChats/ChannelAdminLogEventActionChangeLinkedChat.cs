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
    public partial class ChannelAdminLogEventActionChangeLinkedChat : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 84703944; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public long PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public long NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeLinkedChat(long prevValue, long newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;
        }
#nullable disable
        internal ChannelAdminLogEventActionChangeLinkedChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PrevValue);
            writer.WriteInt64(NewValue);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadInt64();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }

            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadInt64();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }

            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeLinkedChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeLinkedChat();
            newClonedObject.PrevValue = PrevValue;
            newClonedObject.NewValue = NewValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionChangeLinkedChat castedOther)
            {
                return true;
            }

            if (PrevValue != castedOther.PrevValue)
            {
                return true;
            }

            if (NewValue != castedOther.NewValue)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
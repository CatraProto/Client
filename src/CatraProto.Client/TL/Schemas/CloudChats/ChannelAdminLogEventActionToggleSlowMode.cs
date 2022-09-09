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
    public partial class ChannelAdminLogEventActionToggleSlowMode : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1401984889; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public int PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public int NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionToggleSlowMode(int prevValue, int newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;
        }
#nullable disable
        internal ChannelAdminLogEventActionToggleSlowMode()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(PrevValue);
            writer.WriteInt32(NewValue);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadInt32();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }

            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadInt32();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }

            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionToggleSlowMode";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionToggleSlowMode();
            newClonedObject.PrevValue = PrevValue;
            newClonedObject.NewValue = NewValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionToggleSlowMode castedOther)
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
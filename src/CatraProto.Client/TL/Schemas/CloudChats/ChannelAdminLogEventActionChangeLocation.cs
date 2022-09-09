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
    public partial class ChannelAdminLogEventActionChangeLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 241923758; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeLocation(CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase prevValue, CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;
        }
#nullable disable
        internal ChannelAdminLogEventActionChangeLocation()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevValue = writer.WriteObject(PrevValue);
            if (checkprevValue.IsError)
            {
                return checkprevValue;
            }

            var checknewValue = writer.WriteObject(NewValue);
            if (checknewValue.IsError)
            {
                return checknewValue;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }

            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }

            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionChangeLocation();
            var clonePrevValue = (CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase?)PrevValue.Clone();
            if (clonePrevValue is null)
            {
                return null;
            }

            newClonedObject.PrevValue = clonePrevValue;
            var cloneNewValue = (CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase?)NewValue.Clone();
            if (cloneNewValue is null)
            {
                return null;
            }

            newClonedObject.NewValue = cloneNewValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionChangeLocation castedOther)
            {
                return true;
            }

            if (PrevValue.Compare(castedOther.PrevValue))
            {
                return true;
            }

            if (NewValue.Compare(castedOther.NewValue))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
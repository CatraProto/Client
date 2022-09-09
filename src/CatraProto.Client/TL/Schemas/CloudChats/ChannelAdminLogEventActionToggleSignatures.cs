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
    public partial class ChannelAdminLogEventActionToggleSignatures : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 648939889; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public bool NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionToggleSignatures(bool newValue)
        {
            NewValue = newValue;
        }
#nullable disable
        internal ChannelAdminLogEventActionToggleSignatures()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checknewValue = writer.WriteBool(NewValue);
            if (checknewValue.IsError)
            {
                return checknewValue;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynewValue = reader.ReadBool();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }

            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionToggleSignatures";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionToggleSignatures();
            newClonedObject.NewValue = NewValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionToggleSignatures castedOther)
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
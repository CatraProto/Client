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
    public partial class UpdatePhoneCallSignalingData : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 643940105; }

        [Newtonsoft.Json.JsonProperty("phone_call_id")]
        public long PhoneCallId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }


#nullable enable
        public UpdatePhoneCallSignalingData(long phoneCallId, byte[] data)
        {
            PhoneCallId = phoneCallId;
            Data = data;
        }
#nullable disable
        internal UpdatePhoneCallSignalingData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PhoneCallId);

            writer.WriteBytes(Data);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCallId = reader.ReadInt64();
            if (tryphoneCallId.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCallId);
            }

            PhoneCallId = tryphoneCallId.Value;
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updatePhoneCallSignalingData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePhoneCallSignalingData();
            newClonedObject.PhoneCallId = PhoneCallId;
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePhoneCallSignalingData castedOther)
            {
                return true;
            }

            if (PhoneCallId != castedOther.PhoneCallId)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
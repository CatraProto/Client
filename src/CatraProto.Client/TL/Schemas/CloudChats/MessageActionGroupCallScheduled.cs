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
    public partial class MessageActionGroupCallScheduled : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1281329567; }

        [Newtonsoft.Json.JsonProperty("call")] public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_date")]
        public int ScheduleDate { get; set; }


#nullable enable
        public MessageActionGroupCallScheduled(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, int scheduleDate)
        {
            Call = call;
            ScheduleDate = scheduleDate;
        }
#nullable disable
        internal MessageActionGroupCallScheduled()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            writer.WriteInt32(ScheduleDate);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }

            Call = trycall.Value;
            var tryscheduleDate = reader.ReadInt32();
            if (tryscheduleDate.IsError)
            {
                return ReadResult<IObject>.Move(tryscheduleDate);
            }

            ScheduleDate = tryscheduleDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionGroupCallScheduled";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionGroupCallScheduled();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }

            newClonedObject.Call = cloneCall;
            newClonedObject.ScheduleDate = ScheduleDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionGroupCallScheduled castedOther)
            {
                return true;
            }

            if (Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (ScheduleDate != castedOther.ScheduleDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}
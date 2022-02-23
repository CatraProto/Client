using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionGroupCallScheduled : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1281329567;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Call);
            writer.Write(ScheduleDate);
        }

        public override void Deserialize(Reader reader)
        {
            Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            ScheduleDate = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messageActionGroupCallScheduled";
        }
    }
}
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionChangeAbout : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => 1427671598;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public string PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public string NewValue { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionChangeAbout(string prevValue, string newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;
        }
    #nullable disable
        internal ChannelAdminLogEventActionChangeAbout()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PrevValue);
            writer.Write(NewValue);
        }

        public override void Deserialize(Reader reader)
        {
            PrevValue = reader.Read<string>();
            NewValue = reader.Read<string>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeAbout";
        }
    }
}
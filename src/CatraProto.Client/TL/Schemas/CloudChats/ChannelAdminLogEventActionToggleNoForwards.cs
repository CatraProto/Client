using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionToggleNoForwards : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => -886388890;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public bool NewValue { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionToggleNoForwards(bool newValue)
        {
            NewValue = newValue;
        }
    #nullable disable
        internal ChannelAdminLogEventActionToggleNoForwards()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(NewValue);
        }

        public override void Deserialize(Reader reader)
        {
            NewValue = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionToggleNoForwards";
        }
    }
}
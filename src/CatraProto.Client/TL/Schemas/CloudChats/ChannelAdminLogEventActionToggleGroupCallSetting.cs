using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionToggleGroupCallSetting : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => 1456906823;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("join_muted")]
        public bool JoinMuted { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionToggleGroupCallSetting(bool joinMuted)
        {
            JoinMuted = joinMuted;
        }
    #nullable disable
        internal ChannelAdminLogEventActionToggleGroupCallSetting()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(JoinMuted);
        }

        public override void Deserialize(Reader reader)
        {
            JoinMuted = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionToggleGroupCallSetting";
        }
    }
}
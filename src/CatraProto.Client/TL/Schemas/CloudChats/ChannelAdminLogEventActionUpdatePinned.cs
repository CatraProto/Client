using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionUpdatePinned : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => -370660328;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionUpdatePinned(CatraProto.Client.TL.Schemas.CloudChats.MessageBase message)
        {
            Message = message;
        }
    #nullable disable
        internal ChannelAdminLogEventActionUpdatePinned()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Message);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionUpdatePinned";
        }
    }
}
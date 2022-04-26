using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionToggleGroupCallSetting : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1456906823; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkjoinMuted = writer.WriteBool(JoinMuted);
            if (checkjoinMuted.IsError)
            {
                return checkjoinMuted;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryjoinMuted = reader.ReadBool();
            if (tryjoinMuted.IsError)
            {
                return ReadResult<IObject>.Move(tryjoinMuted);
            }
            JoinMuted = tryjoinMuted.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionToggleGroupCallSetting";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionToggleGroupCallSetting
            {
                JoinMuted = JoinMuted
            };
            return newClonedObject;

        }
#nullable disable
    }
}
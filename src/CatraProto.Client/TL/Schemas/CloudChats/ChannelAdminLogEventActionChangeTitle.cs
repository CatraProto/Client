using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionChangeTitle : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -421545947; }

        [Newtonsoft.Json.JsonProperty("prev_value")]
        public string PrevValue { get; set; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public string NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionChangeTitle(string prevValue, string newValue)
        {
            PrevValue = prevValue;
            NewValue = newValue;

        }
#nullable disable
        internal ChannelAdminLogEventActionChangeTitle()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PrevValue);

            writer.WriteString(NewValue);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevValue = reader.ReadString();
            if (tryprevValue.IsError)
            {
                return ReadResult<IObject>.Move(tryprevValue);
            }
            PrevValue = tryprevValue.Value;
            var trynewValue = reader.ReadString();
            if (trynewValue.IsError)
            {
                return ReadResult<IObject>.Move(trynewValue);
            }
            NewValue = trynewValue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangeTitle";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
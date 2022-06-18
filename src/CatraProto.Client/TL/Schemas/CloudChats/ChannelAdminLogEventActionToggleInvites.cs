using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionToggleInvites : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 460916654; }

        [Newtonsoft.Json.JsonProperty("new_value")]
        public bool NewValue { get; set; }


#nullable enable
        public ChannelAdminLogEventActionToggleInvites(bool newValue)
        {
            NewValue = newValue;

        }
#nullable disable
        internal ChannelAdminLogEventActionToggleInvites()
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
            return "channelAdminLogEventActionToggleInvites";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionToggleInvites
            {
                NewValue = NewValue
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionToggleInvites castedOther)
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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChannelMessageViews : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -232346616; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public int Views { get; set; }


#nullable enable
        public UpdateChannelMessageViews(long channelId, int id, int views)
        {
            ChannelId = channelId;
            Id = id;
            Views = views;

        }
#nullable disable
        internal UpdateChannelMessageViews()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);
            writer.WriteInt32(Id);
            writer.WriteInt32(Views);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }
            ChannelId = trychannelId.Value;
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryviews = reader.ReadInt32();
            if (tryviews.IsError)
            {
                return ReadResult<IObject>.Move(tryviews);
            }
            Views = tryviews.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateChannelMessageViews";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelMessageViews
            {
                ChannelId = ChannelId,
                Id = Id,
                Views = Views
            };
            return newClonedObject;

        }
#nullable disable
    }
}
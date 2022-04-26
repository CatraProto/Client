using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsURL : CatraProto.Client.TL.Schemas.CloudChats.StatsURLBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1202287072; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }


#nullable enable
        public StatsURL(string url)
        {
            Url = url;

        }
#nullable disable
        internal StatsURL()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsURL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsURL
            {
                Url = Url
            };
            return newClonedObject;

        }
#nullable disable
    }
}
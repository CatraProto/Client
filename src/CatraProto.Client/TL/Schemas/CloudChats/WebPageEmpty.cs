using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebPageEmpty : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -350980120; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }


#nullable enable
        public WebPageEmpty(long id)
        {
            Id = id;

        }
#nullable disable
        internal WebPageEmpty()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "webPageEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebPageEmpty
            {
                Id = Id
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not WebPageEmpty castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}
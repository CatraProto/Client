using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UserEmpty : CatraProto.Client.TL.Schemas.CloudChats.UserBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -742634630; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }


#nullable enable
        public UserEmpty(long id)
        {
            Id = id;

        }
#nullable disable
        internal UserEmpty()
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
            return "userEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserEmpty
            {
                Id = Id
            };
            return newClonedObject;

        }
#nullable disable
    }
}
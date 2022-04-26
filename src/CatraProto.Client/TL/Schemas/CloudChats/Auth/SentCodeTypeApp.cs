using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCodeTypeApp : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1035688326; }

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }


#nullable enable
        public SentCodeTypeApp(int length)
        {
            Length = length;

        }
#nullable disable
        internal SentCodeTypeApp()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Length);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }
            Length = trylength.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.sentCodeTypeApp";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCodeTypeApp
            {
                Length = Length
            };
            return newClonedObject;

        }
#nullable disable
    }
}
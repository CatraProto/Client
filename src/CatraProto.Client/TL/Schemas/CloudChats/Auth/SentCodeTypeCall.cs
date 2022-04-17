using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCodeTypeCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1398007207; }

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }


#nullable enable
        public SentCodeTypeCall(int length)
        {
            Length = length;

        }
#nullable disable
        internal SentCodeTypeCall()
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
            return "auth.sentCodeTypeCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DhConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1058912715; }

        [Newtonsoft.Json.JsonProperty("random")]
        public sealed override byte[] Random { get; set; }


#nullable enable
        public DhConfigNotModified(byte[] random)
        {
            Random = random;

        }
#nullable disable
        internal DhConfigNotModified()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Random);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrandom = reader.ReadBytes();
            if (tryrandom.IsError)
            {
                return ReadResult<IObject>.Move(tryrandom);
            }
            Random = tryrandom.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.dhConfigNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
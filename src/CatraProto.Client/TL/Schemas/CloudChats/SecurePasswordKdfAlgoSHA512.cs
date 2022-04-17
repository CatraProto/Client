using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePasswordKdfAlgoSHA512 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2042159726; }

        [Newtonsoft.Json.JsonProperty("salt")]
        public byte[] Salt { get; set; }


#nullable enable
        public SecurePasswordKdfAlgoSHA512(byte[] salt)
        {
            Salt = salt;

        }
#nullable disable
        internal SecurePasswordKdfAlgoSHA512()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Salt);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysalt = reader.ReadBytes();
            if (trysalt.IsError)
            {
                return ReadResult<IObject>.Move(trysalt);
            }
            Salt = trysalt.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "securePasswordKdfAlgoSHA512";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
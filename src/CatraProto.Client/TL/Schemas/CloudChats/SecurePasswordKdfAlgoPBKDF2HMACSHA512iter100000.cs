using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
    {
        public static int StaticConstructorId
        {
            get => -1141711456;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("salt")] public byte[] Salt { get; set; }


    #nullable enable
        public SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000(byte[] salt)
        {
            Salt = salt;
        }
    #nullable disable
        internal SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Salt);
        }

        public override void Deserialize(Reader reader)
        {
            Salt = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "securePasswordKdfAlgoPBKDF2HMACSHA512iter100000";
        }
    }
}
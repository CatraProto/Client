using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureCredentialsEncrypted : CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 871426631; }

        [Newtonsoft.Json.JsonProperty("data")]
        public sealed override byte[] Data { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public sealed override byte[] Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public sealed override byte[] Secret { get; set; }


#nullable enable
        public SecureCredentialsEncrypted(byte[] data, byte[] hash, byte[] secret)
        {
            Data = data;
            Hash = hash;
            Secret = secret;

        }
#nullable disable
        internal SecureCredentialsEncrypted()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Data);

            writer.WriteBytes(Hash);

            writer.WriteBytes(Secret);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }
            Data = trydata.Value;
            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trysecret = reader.ReadBytes();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }
            Secret = trysecret.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureCredentialsEncrypted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}
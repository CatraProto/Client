using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalt : CatraProto.Client.TL.Schemas.MTProto.FutureSaltBase
    {
        public static int StaticConstructorId
        {
            get => 155834844;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("valid_since")]
        public sealed override int ValidSince { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }

        [Newtonsoft.Json.JsonProperty("salt")] public sealed override long Salt { get; set; }


    #nullable enable
        public FutureSalt(int validSince, int validUntil, long salt)
        {
            ValidSince = validSince;
            ValidUntil = validUntil;
            Salt = salt;
        }
    #nullable disable
        internal FutureSalt()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ValidSince);
            writer.Write(ValidUntil);
            writer.Write(Salt);
        }

        public override void Deserialize(Reader reader)
        {
            ValidSince = reader.Read<int>();
            ValidUntil = reader.Read<int>();
            Salt = reader.Read<long>();
        }

        public override string ToString()
        {
            return "future_salt";
        }
    }
}
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class TmpPassword : TmpPasswordBase
    {
        public static int StaticConstructorId
        {
            get => -614138572;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("tmp_password")] public override byte[] TmpPasswordField { get; set; }

        [JsonProperty("valid_until")] public override int ValidUntil { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(TmpPasswordField);
            writer.Write(ValidUntil);
        }

        public override void Deserialize(Reader reader)
        {
            TmpPasswordField = reader.Read<byte[]>();
            ValidUntil = reader.Read<int>();
        }

        public override string ToString()
        {
            return "account.tmpPassword";
        }
    }
}
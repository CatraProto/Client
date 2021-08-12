using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class TmpPassword : TmpPasswordBase
	{


        public static int StaticConstructorId { get => -614138572; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("TmpPassword_")]
		public override byte[] TmpPassword_ { get; set; }

[JsonPropertyName("valid_until")]
		public override int ValidUntil { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TmpPassword_);
			writer.Write(ValidUntil);

		}

		public override void Deserialize(Reader reader)
		{
			TmpPassword_ = reader.Read<byte[]>();
			ValidUntil = reader.Read<int>();
		}

		public override string ToString()
		{
			return "account.tmpPassword";
		}
	}
}
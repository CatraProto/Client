using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginTokenMigrateTo : LoginTokenBase
	{


        public static int StaticConstructorId { get => 110008598; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dc_id")]
		public int DcId { get; set; }

[JsonPropertyName("token")]
		public byte[] Token { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(Token);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			Token = reader.Read<byte[]>();

		}
	}
}
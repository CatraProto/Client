using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCallSignalingData : UpdateBase
	{


        public static int StaticConstructorId { get => 643940105; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("phone_call_id")]
		public long PhoneCallId { get; set; }

[JsonPropertyName("data")]
		public byte[] Data { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCallId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCallId = reader.Read<long>();
			Data = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "updatePhoneCallSignalingData";
		}
	}
}
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ContactStatus : ContactStatusBase
	{


        public static int StaticConstructorId { get => -748155807; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("status")]
		public override UserStatusBase Status { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Status);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Status = reader.Read<UserStatusBase>();
		}

		public override string ToString()
		{
			return "contactStatus";
		}
	}
}
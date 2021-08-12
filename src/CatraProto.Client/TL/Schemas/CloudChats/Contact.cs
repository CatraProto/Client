using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Contact : ContactBase
	{


        public static int StaticConstructorId { get => -116274796; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("mutual")]
		public override bool Mutual { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Mutual);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Mutual = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "contact";
		}
	}
}
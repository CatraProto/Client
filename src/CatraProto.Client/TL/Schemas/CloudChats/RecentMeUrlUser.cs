using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlUser : RecentMeUrlBase
	{


        public static int StaticConstructorId { get => -1917045962; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			UserId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "recentMeUrlUser";
		}
	}
}
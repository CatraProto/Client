using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopInviter : StatsGroupTopInviterBase
	{


        public static int StaticConstructorId { get => 831924812; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("invitations")]
		public override int Invitations { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Invitations);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Invitations = reader.Read<int>();

		}
	}
}
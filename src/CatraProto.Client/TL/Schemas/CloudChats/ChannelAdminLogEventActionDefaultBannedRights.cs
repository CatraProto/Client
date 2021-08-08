using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 771095562; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_banned_rights")]
		public ChatBannedRightsBase PrevBannedRights { get; set; }

[JsonPropertyName("new_banned_rights")]
		public ChatBannedRightsBase NewBannedRights { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevBannedRights);
			writer.Write(NewBannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			PrevBannedRights = reader.Read<ChatBannedRightsBase>();
			NewBannedRights = reader.Read<ChatBannedRightsBase>();

		}
	}
}
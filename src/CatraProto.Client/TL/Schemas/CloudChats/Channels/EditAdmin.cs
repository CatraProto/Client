using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditAdmin : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -751007486; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("channel")]
		public InputChannelBase Channel { get; set; }

[JsonPropertyName("user_id")]
		public InputUserBase UserId { get; set; }

[JsonPropertyName("admin_rights")]
		public ChatAdminRightsBase AdminRights { get; set; }

[JsonPropertyName("rank")]
		public string Rank { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(AdminRights);
			writer.Write(Rank);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
			AdminRights = reader.Read<ChatAdminRightsBase>();
			Rank = reader.Read<string>();
		}

		public override string ToString()
		{
			return "channels.editAdmin";
		}
	}
}
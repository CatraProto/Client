using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetGameScore : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EditMessage = 1 << 0,
			Force = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1896289088; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("edit_message")]
		public bool EditMessage { get; set; }

[JsonPropertyName("force")]
		public bool Force { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[JsonPropertyName("score")]
		public int Score { get; set; }


		public void UpdateFlags() 
		{
			Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.Read<int>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Score = reader.Read<int>();

		}
	}
}
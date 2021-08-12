using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetInlineGameScore : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EditMessage = 1 << 0,
			Force = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 363700068; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("edit_message")]
		public bool EditMessage { get; set; }

[JsonPropertyName("force")]
		public bool Force { get; set; }

		[JsonPropertyName("id")] public InputBotInlineMessageIDBase Id { get; set; }

		[JsonPropertyName("user_id")] public InputUserBase UserId { get; set; }

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
			writer.Write(Id);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<InputBotInlineMessageIDBase>();
			UserId = reader.Read<InputUserBase>();
			Score = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.setInlineGameScore";
		}
	}
}
using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SetCallRating : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			UserInitiative = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1508562471; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("user_initiative")]
		public bool UserInitiative { get; set; }

[JsonPropertyName("peer")]
		public InputPhoneCallBase Peer { get; set; }

[JsonPropertyName("rating")]
		public int Rating { get; set; }

[JsonPropertyName("comment")]
		public string Comment { get; set; }


		public void UpdateFlags() 
		{
			Flags = UserInitiative ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Rating);
			writer.Write(Comment);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UserInitiative = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputPhoneCallBase>();
			Rating = reader.Read<int>();
			Comment = reader.Read<string>();
		}

		public override string ToString()
		{
			return "phone.setCallRating";
		}
	}
}
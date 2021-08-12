using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class RequestCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1124046573; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(PhoneCallBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("video")]
		public bool Video { get; set; }

[JsonPropertyName("user_id")]
		public InputUserBase UserId { get; set; }

[JsonPropertyName("random_id")]
		public int RandomId { get; set; }

[JsonPropertyName("g_a_hash")]
		public byte[] GAHash { get; set; }

[JsonPropertyName("protocol")]
		public PhoneCallProtocolBase Protocol { get; set; }


		public void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(RandomId);
			writer.Write(GAHash);
			writer.Write(Protocol);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<InputUserBase>();
			RandomId = reader.Read<int>();
			GAHash = reader.Read<byte[]>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
		}

		public override string ToString()
		{
			return "phone.requestCall";
		}
	}
}
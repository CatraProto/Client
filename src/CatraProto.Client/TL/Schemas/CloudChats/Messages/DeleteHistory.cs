using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteHistory : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			JustClear = 1 << 0,
			Revoke = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 469850889; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(AffectedHistoryBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("just_clear")]
		public bool JustClear { get; set; }

[JsonPropertyName("revoke")]
		public bool Revoke { get; set; }

[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("max_id")]
		public int MaxId { get; set; }


		public void UpdateFlags() 
		{
			Flags = JustClear ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Revoke ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(MaxId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			JustClear = FlagsHelper.IsFlagSet(Flags, 0);
			Revoke = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<InputPeerBase>();
			MaxId = reader.Read<int>();

		}
	}
}
using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdatePinnedMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 0,
			Unpin = 1 << 1,
			PmOneside = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -760547348; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("silent")]
		public bool Silent { get; set; }

[JsonPropertyName("unpin")]
		public bool Unpin { get; set; }

[JsonPropertyName("pm_oneside")]
		public bool PmOneside { get; set; }

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }


		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Unpin ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = PmOneside ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Unpin = FlagsHelper.IsFlagSet(Flags, 1);
			PmOneside = FlagsHelper.IsFlagSet(Flags, 2);
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.updatePinnedMessage";
		}
	}
}
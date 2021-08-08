using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ToggleStickerSets : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Uninstall = 1 << 0,
			Archive = 1 << 1,
			Unarchive = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1257951254; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("uninstall")]
		public bool Uninstall { get; set; }

[JsonPropertyName("archive")]
		public bool Archive { get; set; }

[JsonPropertyName("unarchive")]
		public bool Unarchive { get; set; }

[JsonPropertyName("stickersets")]
		public IList<InputStickerSetBase> Stickersets { get; set; }


		public void UpdateFlags() 
		{
			Flags = Uninstall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Archive ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Unarchive ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Stickersets);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Uninstall = FlagsHelper.IsFlagSet(Flags, 0);
			Archive = FlagsHelper.IsFlagSet(Flags, 1);
			Unarchive = FlagsHelper.IsFlagSet(Flags, 2);
			Stickersets = reader.ReadVector<InputStickerSetBase>();

		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetRecentStickers : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Attached = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1587647177; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("attached")]
		public bool Attached { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{
			Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Attached = FlagsHelper.IsFlagSet(Flags, 0);
			Hash = reader.Read<int>();

		}
	}
}
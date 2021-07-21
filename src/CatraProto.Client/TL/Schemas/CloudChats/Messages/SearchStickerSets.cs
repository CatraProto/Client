using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchStickerSets : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludeFeatured = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1028140917; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("exclude_featured")]
		public bool ExcludeFeatured { get; set; }

[JsonPropertyName("q")]
		public string Q { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{
			Flags = ExcludeFeatured ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Q);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ExcludeFeatured = FlagsHelper.IsFlagSet(Flags, 0);
			Q = reader.Read<string>();
			Hash = reader.Read<int>();

		}
	}
}
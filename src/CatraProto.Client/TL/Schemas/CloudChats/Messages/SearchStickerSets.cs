using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchStickerSets : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludeFeatured = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1028140917; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_featured")]
		public bool ExcludeFeatured { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
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
		
		public override string ToString()
		{
		    return "messages.searchStickerSets";
		}
	}
}
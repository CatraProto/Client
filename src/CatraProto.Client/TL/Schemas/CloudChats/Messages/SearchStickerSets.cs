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
        public static int ConstructorId { get => 896555914; }
        
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
		public long Hash { get; set; }

        
        #nullable enable
 public SearchStickerSets (string q,long hash)
{
 Q = q;
Hash = hash;
 
}
#nullable disable
                
        internal SearchStickerSets() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = ExcludeFeatured ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Hash = reader.Read<long>();

		}

		public override string ToString()
		{
		    return "messages.searchStickerSets";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WallPaper : CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Default = 1 << 1,
			Pattern = 1 << 3,
			Dark = 1 << 4,
			Settings = 1 << 2
		}

        public static int StaticConstructorId { get => -1539849235; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("creator")]
		public bool Creator { get; set; }

[Newtonsoft.Json.JsonProperty("default")]
		public sealed override bool Default { get; set; }

[Newtonsoft.Json.JsonProperty("pattern")]
		public bool Pattern { get; set; }

[Newtonsoft.Json.JsonProperty("dark")]
		public sealed override bool Dark { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("slug")]
		public string Slug { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


        #nullable enable
 public WallPaper (long id,long accessHash,string slug,CatraProto.Client.TL.Schemas.CloudChats.DocumentBase document)
{
 Id = id;
AccessHash = accessHash;
Slug = slug;
Document = document;
 
}
#nullable disable
        internal WallPaper() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Pattern ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(AccessHash);
			writer.Write(Slug);
			writer.Write(Document);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Settings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Flags = reader.Read<int>();
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Pattern = FlagsHelper.IsFlagSet(Flags, 3);
			Dark = FlagsHelper.IsFlagSet(Flags, 4);
			AccessHash = reader.Read<long>();
			Slug = reader.Read<string>();
			Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
			}


		}
				
		public override string ToString()
		{
		    return "wallPaper";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Page : CatraProto.Client.TL.Schemas.CloudChats.PageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Part = 1 << 0,
			Rtl = 1 << 1,
			V2 = 1 << 2,
			Views = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1738178803; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("part")]
		public sealed override bool Part { get; set; }

[Newtonsoft.Json.JsonProperty("rtl")]
		public sealed override bool Rtl { get; set; }

[Newtonsoft.Json.JsonProperty("v2")]
		public sealed override bool V2 { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

[Newtonsoft.Json.JsonProperty("photos")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public sealed override int? Views { get; set; }


        #nullable enable
 public Page (string url,IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks,IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos,IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
{
 Url = url;
Blocks = blocks;
Photos = photos;
Documents = documents;
 
}
#nullable disable
        internal Page() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Part ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Rtl ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = V2 ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Url);
			writer.Write(Blocks);
			writer.Write(Photos);
			writer.Write(Documents);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Views.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Part = FlagsHelper.IsFlagSet(Flags, 0);
			Rtl = FlagsHelper.IsFlagSet(Flags, 1);
			V2 = FlagsHelper.IsFlagSet(Flags, 2);
			Url = reader.Read<string>();
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Photos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			Documents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Views = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "page";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
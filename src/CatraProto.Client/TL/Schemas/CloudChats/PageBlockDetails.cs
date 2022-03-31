using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockDetails : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Open = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1987480557; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("open")]
		public bool Open { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }


        #nullable enable
 public PageBlockDetails (IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks,CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title)
{
 Blocks = blocks;
Title = title;
 
}
#nullable disable
        internal PageBlockDetails() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Open ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Blocks);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Open = FlagsHelper.IsFlagSet(Flags, 0);
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Title = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockDetails";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
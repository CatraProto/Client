using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DraftMessageEmpty : CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Date = 1 << 0
		}

        public static int StaticConstructorId { get => 453805082; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int? Date { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Date == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Date.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Date = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "draftMessageEmpty";
		}
	}
}
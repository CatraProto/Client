using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraph : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ZoomToken = 1 << 0
		}

        public static int StaticConstructorId { get => -1901828938; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("json")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Json { get; set; }

[Newtonsoft.Json.JsonProperty("zoom_token")]
		public string ZoomToken { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ZoomToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Json);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ZoomToken);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Json = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ZoomToken = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "statsGraph";
		}
	}
}
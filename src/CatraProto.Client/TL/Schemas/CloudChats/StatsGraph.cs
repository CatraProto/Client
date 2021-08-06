using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("json")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Json { get; set; }

[JsonPropertyName("zoom_token")]
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
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetDifference : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			PtsTotalLimit = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 630429265; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_total_limit")]
		public int? PtsTotalLimit { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("qts")]
		public int Qts { get; set; }


		public void UpdateFlags() 
		{
			Flags = PtsTotalLimit == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Pts);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PtsTotalLimit.Value);
			}

			writer.Write(Date);
			writer.Write(Qts);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PtsTotalLimit = reader.Read<int>();
			}

			Date = reader.Read<int>();
			Qts = reader.Read<int>();

		}
	}
}
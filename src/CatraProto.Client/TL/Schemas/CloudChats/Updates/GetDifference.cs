using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 630429265; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_total_limit")]
		public int? PtsTotalLimit { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }

        
        #nullable enable
 public GetDifference (int pts,int date,int qts)
{
 Pts = pts;
Date = date;
Qts = qts;
 
}
#nullable disable
                
        internal GetDifference() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = PtsTotalLimit == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override string ToString()
		{
		    return "updates.getDifference";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
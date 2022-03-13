using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AffectedHistory : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase
	{


        public static int StaticConstructorId { get => -1269012015; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pts")]
		public sealed override int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public sealed override int PtsCount { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }


        #nullable enable
 public AffectedHistory (int pts,int ptsCount,int offset)
{
 Pts = pts;
PtsCount = ptsCount;
Offset = offset;
 
}
#nullable disable
        internal AffectedHistory() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Offset);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Offset = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "messages.affectedHistory";
		}
	}
}
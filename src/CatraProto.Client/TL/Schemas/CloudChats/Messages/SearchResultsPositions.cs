using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchResultsPositions : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1404185519; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("positions")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> Positions { get; set; }


        #nullable enable
 public SearchResultsPositions (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> positions)
{
 Count = count;
Positions = positions;
 
}
#nullable disable
        internal SearchResultsPositions() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Positions);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Positions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase>();

		}
		
		public override string ToString()
		{
		    return "messages.searchResultsPositions";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
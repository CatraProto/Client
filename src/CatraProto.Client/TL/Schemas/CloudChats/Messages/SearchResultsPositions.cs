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


        public static int StaticConstructorId { get => 1404185519; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("positions")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> Positions { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}
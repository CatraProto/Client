using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GeoPointEmpty : CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 286776671; }
        

        
        public GeoPointEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "geoPointEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
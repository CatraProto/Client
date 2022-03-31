using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryForwardChats : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -68239120; }
        

        
        public TopPeerCategoryForwardChats() 
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
		    return "topPeerCategoryForwardChats";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
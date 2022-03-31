using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryForwardUsers : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1472172887; }
        

        
        public TopPeerCategoryForwardUsers() 
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
		    return "topPeerCategoryForwardUsers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
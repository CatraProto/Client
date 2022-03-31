using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryBotsPM : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1419371685; }
        

        
        public TopPeerCategoryBotsPM() 
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
		    return "topPeerCategoryBotsPM";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryPhoneCalls : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 511092620; }
        

        
        public TopPeerCategoryPhoneCalls() 
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
		    return "topPeerCategoryPhoneCalls";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
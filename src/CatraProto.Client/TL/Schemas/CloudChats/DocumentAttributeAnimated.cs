using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeAnimated : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 297109817; }
        

        
        public DocumentAttributeAnimated() 
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
		    return "documentAttributeAnimated";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
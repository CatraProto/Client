using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeHasStickers : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1744710921; }
        

        
        public DocumentAttributeHasStickers() 
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
		    return "documentAttributeHasStickers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
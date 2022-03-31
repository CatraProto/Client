using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextEmpty : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -599948721; }
        

        
        public TextEmpty() 
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
		    return "textEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
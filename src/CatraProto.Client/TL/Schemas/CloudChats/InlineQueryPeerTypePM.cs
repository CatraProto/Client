using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InlineQueryPeerTypePM : CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2093215828; }
        

        
        public InlineQueryPeerTypePM() 
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
		    return "inlineQueryPeerTypePM";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InlineQueryPeerTypeSameBotPM : CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 813821341; }
        

        
        public InlineQueryPeerTypeSameBotPM() 
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
		    return "inlineQueryPeerTypeSameBotPM";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelLocationEmpty : CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1078612597; }
        

        
        public ChannelLocationEmpty() 
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
		    return "channelLocationEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
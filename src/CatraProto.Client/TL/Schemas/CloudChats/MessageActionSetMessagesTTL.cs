using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSetMessagesTTL : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1441072131; }
        
[Newtonsoft.Json.JsonProperty("period")]
		public int Period { get; set; }


        #nullable enable
 public MessageActionSetMessagesTTL (int period)
{
 Period = period;
 
}
#nullable disable
        internal MessageActionSetMessagesTTL() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Period);

		}

		public override void Deserialize(Reader reader)
		{
			Period = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messageActionSetMessagesTTL";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionBotAllowed : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        public static int StaticConstructorId { get => -1410748418; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("domain")]
		public string Domain { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Domain);

		}

		public override void Deserialize(Reader reader)
		{
			Domain = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messageActionBotAllowed";
		}
	}
}
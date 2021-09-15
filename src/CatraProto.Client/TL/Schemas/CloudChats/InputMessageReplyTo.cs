using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessageReplyTo : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
	{


        public static int StaticConstructorId { get => -1160215659; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputMessageReplyTo";
		}
	}
}
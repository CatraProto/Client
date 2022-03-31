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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1160215659; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }


        #nullable enable
 public InputMessageReplyTo (int id)
{
 Id = id;
 
}
#nullable disable
        internal InputMessageReplyTo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
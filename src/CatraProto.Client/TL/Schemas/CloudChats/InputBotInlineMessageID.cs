using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineMessageID : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase
	{


        public static int StaticConstructorId { get => -1995686519; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public override int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public override long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(Id);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputBotInlineMessageID";
		}
	}
}
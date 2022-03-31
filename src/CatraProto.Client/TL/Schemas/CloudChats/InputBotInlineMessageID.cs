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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1995686519; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public sealed override int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }


        #nullable enable
 public InputBotInlineMessageID (int dcId,long id,long accessHash)
{
 DcId = dcId;
Id = id;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputBotInlineMessageID() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
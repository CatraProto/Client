using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessageID : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 1318109142; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public long RandomId { get; set; }


        #nullable enable
 public UpdateMessageID (int id,long randomId)
{
 Id = id;
RandomId = randomId;
 
}
#nullable disable
        internal UpdateMessageID() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(RandomId);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			RandomId = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "updateMessageID";
		}
	}
}
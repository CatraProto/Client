using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GroupCallDiscarded : CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2004925620; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("duration")]
		public int Duration { get; set; }


        #nullable enable
 public GroupCallDiscarded (long id,long accessHash,int duration)
{
 Id = id;
AccessHash = accessHash;
Duration = duration;
 
}
#nullable disable
        internal GroupCallDiscarded() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Duration);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Duration = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "groupCallDiscarded";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
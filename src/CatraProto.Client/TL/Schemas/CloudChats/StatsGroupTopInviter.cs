using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGroupTopInviter : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase
	{


        public static int StaticConstructorId { get => 831924812; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("invitations")]
		public override int Invitations { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Invitations);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Invitations = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "statsGroupTopInviter";
		}
	}
}
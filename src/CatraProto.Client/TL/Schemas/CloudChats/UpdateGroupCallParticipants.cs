using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateGroupCallParticipants : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -219423922; }
        
[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }


        #nullable enable
 public UpdateGroupCallParticipants (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants,int version)
{
 Call = call;
Participants = participants;
Version = version;
 
}
#nullable disable
        internal UpdateGroupCallParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Participants);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
			Version = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateGroupCallParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
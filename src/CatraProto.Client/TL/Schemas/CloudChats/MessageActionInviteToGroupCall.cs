using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionInviteToGroupCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1345295095; }
        
[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<long> Users { get; set; }


        #nullable enable
 public MessageActionInviteToGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,IList<long> users)
{
 Call = call;
Users = users;
 
}
#nullable disable
        internal MessageActionInviteToGroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Users = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionInviteToGroupCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
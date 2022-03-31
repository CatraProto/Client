using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatAddUser : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 365886720; }
        
[Newtonsoft.Json.JsonProperty("users")]
		public IList<long> Users { get; set; }


        #nullable enable
 public MessageActionChatAddUser (IList<long> users)
{
 Users = users;
 
}
#nullable disable
        internal MessageActionChatAddUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionChatAddUser";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
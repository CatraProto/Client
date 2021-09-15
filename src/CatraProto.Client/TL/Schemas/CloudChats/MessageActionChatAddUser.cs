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


        public static int StaticConstructorId { get => 1217033015; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("users")]
		public IList<int> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<int>();

		}
				
		public override string ToString()
		{
		    return "messageActionChatAddUser";
		}
	}
}
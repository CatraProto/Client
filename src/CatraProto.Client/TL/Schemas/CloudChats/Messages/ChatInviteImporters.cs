using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatInviteImporters : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase
	{


        public static int StaticConstructorId { get => -2118733814; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("importers")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase> Importers { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Importers);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Importers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "messages.chatInviteImporters";
		}
	}
}
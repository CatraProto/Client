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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2118733814; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("importers")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase> Importers { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChatInviteImporters (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase> importers,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Count = count;
Importers = importers;
Users = users;
 
}
#nullable disable
        internal ChatInviteImporters() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
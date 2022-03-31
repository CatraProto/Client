using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteRevokedExportedChatInvites : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1452833749; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("admin_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase AdminId { get; set; }

        
        #nullable enable
 public DeleteRevokedExportedChatInvites (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase adminId)
{
 Peer = peer;
AdminId = adminId;
 
}
#nullable disable
                
        internal DeleteRevokedExportedChatInvites() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(AdminId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			AdminId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}

		public override string ToString()
		{
		    return "messages.deleteRevokedExportedChatInvites";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
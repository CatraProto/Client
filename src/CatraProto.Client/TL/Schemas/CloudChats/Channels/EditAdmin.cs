using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditAdmin : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -751007486; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("admin_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

[Newtonsoft.Json.JsonProperty("rank")]
		public string Rank { get; set; }

        
        #nullable enable
 public EditAdmin (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights,string rank)
{
 Channel = channel;
UserId = userId;
AdminRights = adminRights;
Rank = rank;
 
}
#nullable disable
                
        internal EditAdmin() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(AdminRights);
			writer.Write(Rank);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			AdminRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
			Rank = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "channels.editAdmin";
		}
	}
}
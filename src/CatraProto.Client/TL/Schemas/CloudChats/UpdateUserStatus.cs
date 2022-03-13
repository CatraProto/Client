using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserStatus : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -440534818; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }


        #nullable enable
 public UpdateUserStatus (long userId,CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase status)
{
 UserId = userId;
Status = status;
 
}
#nullable disable
        internal UpdateUserStatus() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Status);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Status = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase>();

		}
				
		public override string ToString()
		{
		    return "updateUserStatus";
		}
	}
}
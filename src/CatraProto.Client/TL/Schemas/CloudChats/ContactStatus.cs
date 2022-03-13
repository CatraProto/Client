using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ContactStatus : CatraProto.Client.TL.Schemas.CloudChats.ContactStatusBase
	{


        public static int StaticConstructorId { get => 383348795; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }


        #nullable enable
 public ContactStatus (long userId,CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase status)
{
 UserId = userId;
Status = status;
 
}
#nullable disable
        internal ContactStatus() 
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
		    return "contactStatus";
		}
	}
}
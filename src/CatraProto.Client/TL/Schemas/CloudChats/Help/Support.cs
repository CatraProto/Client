using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class Support : CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 398898678; }
        
[Newtonsoft.Json.JsonProperty("phone_number")]
		public sealed override string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("user")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }


        #nullable enable
 public Support (string phoneNumber,CatraProto.Client.TL.Schemas.CloudChats.UserBase user)
{
 PhoneNumber = phoneNumber;
User = user;
 
}
#nullable disable
        internal Support() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(User);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			User = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "help.support";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
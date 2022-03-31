using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusOnline : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -306628279; }
        
[Newtonsoft.Json.JsonProperty("expires")]
		public int Expires { get; set; }


        #nullable enable
 public UserStatusOnline (int expires)
{
 Expires = expires;
 
}
#nullable disable
        internal UserStatusOnline() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "userStatusOnline";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusOffline : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 9203775; }
        
[Newtonsoft.Json.JsonProperty("was_online")]
		public int WasOnline { get; set; }


        #nullable enable
 public UserStatusOffline (int wasOnline)
{
 WasOnline = wasOnline;
 
}
#nullable disable
        internal UserStatusOffline() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(WasOnline);

		}

		public override void Deserialize(Reader reader)
		{
			WasOnline = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "userStatusOffline";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
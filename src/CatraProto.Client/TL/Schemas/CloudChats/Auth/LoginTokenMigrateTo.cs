using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginTokenMigrateTo : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
	{


        public static int StaticConstructorId { get => 110008598; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("token")]
		public byte[] Token { get; set; }


        #nullable enable
 public LoginTokenMigrateTo (int dcId,byte[] token)
{
 DcId = dcId;
Token = token;
 
}
#nullable disable
        internal LoginTokenMigrateTo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(Token);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			Token = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "auth.loginTokenMigrateTo";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class PasswordRecovery : CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 326715557; }
        
[Newtonsoft.Json.JsonProperty("email_pattern")]
		public sealed override string EmailPattern { get; set; }


        #nullable enable
 public PasswordRecovery (string emailPattern)
{
 EmailPattern = emailPattern;
 
}
#nullable disable
        internal PasswordRecovery() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(EmailPattern);

		}

		public override void Deserialize(Reader reader)
		{
			EmailPattern = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "auth.passwordRecovery";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
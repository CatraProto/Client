using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ResetPasswordFailedWait : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
	{


        public static int StaticConstructorId { get => -478701471; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("retry_date")]
		public int RetryDate { get; set; }


        #nullable enable
 public ResetPasswordFailedWait (int retryDate)
{
 RetryDate = retryDate;
 
}
#nullable disable
        internal ResetPasswordFailedWait() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(RetryDate);

		}

		public override void Deserialize(Reader reader)
		{
			RetryDate = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "account.resetPasswordFailedWait";
		}
	}
}
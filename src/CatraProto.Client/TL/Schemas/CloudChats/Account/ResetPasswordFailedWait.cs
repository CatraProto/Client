using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ResetPasswordFailedWait : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -478701471; }
        
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(RetryDate);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryretryDate = reader.ReadInt32();
if(tryretryDate.IsError){
return ReadResult<IObject>.Move(tryretryDate);
}
RetryDate = tryretryDate.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "account.resetPasswordFailedWait";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
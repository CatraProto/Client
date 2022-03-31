using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ResetPasswordRequestedWait : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -370148227; }
        
[Newtonsoft.Json.JsonProperty("until_date")]
		public int UntilDate { get; set; }


        #nullable enable
 public ResetPasswordRequestedWait (int untilDate)
{
 UntilDate = untilDate;
 
}
#nullable disable
        internal ResetPasswordRequestedWait() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UntilDate);

		}

		public override void Deserialize(Reader reader)
		{
			UntilDate = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "account.resetPasswordRequestedWait";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
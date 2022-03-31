using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AccountDaysTTL : CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1194283041; }
        
[Newtonsoft.Json.JsonProperty("days")]
		public sealed override int Days { get; set; }


        #nullable enable
 public AccountDaysTTL (int days)
{
 Days = days;
 
}
#nullable disable
        internal AccountDaysTTL() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Days);

		}

		public override void Deserialize(Reader reader)
		{
			Days = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "accountDaysTTL";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
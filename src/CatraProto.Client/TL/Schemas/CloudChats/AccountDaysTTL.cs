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


        public static int StaticConstructorId { get => -1194283041; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("days")]
		public override int Days { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}
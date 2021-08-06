using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AccountDaysTTL : CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase
	{


        public static int StaticConstructorId { get => -1194283041; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("days")]
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
	}
}
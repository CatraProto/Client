using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeMissedCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
	{


        public static int StaticConstructorId { get => -2113903484; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prefix")]
		public string Prefix { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public int Length { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Prefix);
			writer.Write(Length);

		}

		public override void Deserialize(Reader reader)
		{
			Prefix = reader.Read<string>();
			Length = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "auth.sentCodeTypeMissedCall";
		}
	}
}
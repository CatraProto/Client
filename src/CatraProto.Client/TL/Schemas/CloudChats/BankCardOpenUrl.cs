using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BankCardOpenUrl : CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase
	{


        public static int StaticConstructorId { get => -177732982; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("name")]
		public override string Name { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Name = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "bankCardOpenUrl";
		}
	}
}
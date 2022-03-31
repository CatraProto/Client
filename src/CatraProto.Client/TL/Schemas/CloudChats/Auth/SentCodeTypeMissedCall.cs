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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2113903484; }
        
[Newtonsoft.Json.JsonProperty("prefix")]
		public string Prefix { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public int Length { get; set; }


        #nullable enable
 public SentCodeTypeMissedCall (string prefix,int length)
{
 Prefix = prefix;
Length = length;
 
}
#nullable disable
        internal SentCodeTypeMissedCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
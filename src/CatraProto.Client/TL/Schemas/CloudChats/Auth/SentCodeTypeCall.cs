using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1398007207; }
        
[Newtonsoft.Json.JsonProperty("length")]
		public int Length { get; set; }


        #nullable enable
 public SentCodeTypeCall (int length)
{
 Length = length;
 
}
#nullable disable
        internal SentCodeTypeCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Length);

		}

		public override void Deserialize(Reader reader)
		{
			Length = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "auth.sentCodeTypeCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
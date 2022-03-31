using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeApp : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1035688326; }
        
[Newtonsoft.Json.JsonProperty("length")]
		public int Length { get; set; }


        #nullable enable
 public SentCodeTypeApp (int length)
{
 Length = length;
 
}
#nullable disable
        internal SentCodeTypeApp() 
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
		    return "auth.sentCodeTypeApp";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
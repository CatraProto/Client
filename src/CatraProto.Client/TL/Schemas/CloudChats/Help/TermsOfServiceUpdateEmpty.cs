using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdateEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
	{


        public static int StaticConstructorId { get => -483352705; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("expires")]
		public override int Expires { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
	}
}
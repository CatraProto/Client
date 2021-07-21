using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureRequiredTypeOneOf : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
	{


        public static int StaticConstructorId { get => 41187252; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("types")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> Types { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Types);

		}

		public override void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase>();

		}
	}
}
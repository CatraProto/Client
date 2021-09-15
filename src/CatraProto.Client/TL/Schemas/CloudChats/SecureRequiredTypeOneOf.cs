using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureRequiredTypeOneOf : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
	{


        public static int StaticConstructorId { get => 41187252; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("types")]
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
				
		public override string ToString()
		{
		    return "secureRequiredTypeOneOf";
		}
	}
}
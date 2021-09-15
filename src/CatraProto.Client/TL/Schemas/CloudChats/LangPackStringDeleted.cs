using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackStringDeleted : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
	{


        public static int StaticConstructorId { get => 695856818; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public override string Key { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "langPackStringDeleted";
		}
	}
}
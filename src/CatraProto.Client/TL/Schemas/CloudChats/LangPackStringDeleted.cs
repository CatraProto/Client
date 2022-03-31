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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 695856818; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public sealed override string Key { get; set; }


        #nullable enable
 public LangPackStringDeleted (string key)
{
 Key = key;
 
}
#nullable disable
        internal LangPackStringDeleted() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
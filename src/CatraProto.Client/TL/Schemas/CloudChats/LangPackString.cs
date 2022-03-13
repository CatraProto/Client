using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackString : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
	{


        public static int StaticConstructorId { get => -892239370; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public sealed override string Key { get; set; }

[Newtonsoft.Json.JsonProperty("value")]
		public string Value { get; set; }


        #nullable enable
 public LangPackString (string key,string value)
{
 Key = key;
Value = value;
 
}
#nullable disable
        internal LangPackString() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();
			Value = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "langPackString";
		}
	}
}
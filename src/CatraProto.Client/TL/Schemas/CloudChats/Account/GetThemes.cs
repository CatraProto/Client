using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetThemes : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1913054296; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("format")]
		public string Format { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

        
        #nullable enable
 public GetThemes (string format,long hash)
{
 Format = format;
Hash = hash;
 
}
#nullable disable
                
        internal GetThemes() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Format);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Format = reader.Read<string>();
			Hash = reader.Read<long>();

		}

		public override string ToString()
		{
		    return "account.getThemes";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
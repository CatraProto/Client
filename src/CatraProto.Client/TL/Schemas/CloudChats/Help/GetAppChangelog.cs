using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetAppChangelog : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1877938321; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("prev_app_version")]
		public string PrevAppVersion { get; set; }

        
        #nullable enable
 public GetAppChangelog (string prevAppVersion)
{
 PrevAppVersion = prevAppVersion;
 
}
#nullable disable
                
        internal GetAppChangelog() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PrevAppVersion);

		}

		public void Deserialize(Reader reader)
		{
			PrevAppVersion = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "help.getAppChangelog";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
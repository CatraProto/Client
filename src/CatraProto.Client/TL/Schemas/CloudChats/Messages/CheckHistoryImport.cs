using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CheckHistoryImport : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1140726259; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("import_head")]
		public string ImportHead { get; set; }

        
        #nullable enable
 public CheckHistoryImport (string importHead)
{
 ImportHead = importHead;
 
}
#nullable disable
                
        internal CheckHistoryImport() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ImportHead);

		}

		public void Deserialize(Reader reader)
		{
			ImportHead = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "messages.checkHistoryImport";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
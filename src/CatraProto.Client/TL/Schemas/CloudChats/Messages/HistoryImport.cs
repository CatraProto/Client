using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class HistoryImport : CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 375566091; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }


        #nullable enable
 public HistoryImport (long id)
{
 Id = id;
 
}
#nullable disable
        internal HistoryImport() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messages.historyImport";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
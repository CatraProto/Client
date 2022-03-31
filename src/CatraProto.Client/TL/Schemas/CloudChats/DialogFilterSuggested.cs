using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFilterSuggested : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2004110666; }
        
[Newtonsoft.Json.JsonProperty("filter")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public sealed override string Description { get; set; }


        #nullable enable
 public DialogFilterSuggested (CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase filter,string description)
{
 Filter = filter;
Description = description;
 
}
#nullable disable
        internal DialogFilterSuggested() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Filter);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
			Description = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "dialogFilterSuggested";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
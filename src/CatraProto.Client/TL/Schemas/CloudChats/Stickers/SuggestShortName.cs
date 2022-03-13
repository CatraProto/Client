using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class SuggestShortName : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1303364867; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortNameBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

        
        #nullable enable
 public SuggestShortName (string title)
{
 Title = title;
 
}
#nullable disable
                
        internal SuggestShortName() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Title);

		}

		public void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "stickers.suggestShortName";
		}
	}
}
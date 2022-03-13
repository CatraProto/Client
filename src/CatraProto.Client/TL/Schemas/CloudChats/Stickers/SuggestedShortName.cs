using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class SuggestedShortName : CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortNameBase
	{


        public static int StaticConstructorId { get => -2046910401; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("short_name")]
		public sealed override string ShortName { get; set; }


        #nullable enable
 public SuggestedShortName (string shortName)
{
 ShortName = shortName;
 
}
#nullable disable
        internal SuggestedShortName() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			ShortName = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "stickers.suggestedShortName";
		}
	}
}
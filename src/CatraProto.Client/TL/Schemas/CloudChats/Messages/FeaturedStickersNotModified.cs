using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FeaturedStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -958657434; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }


        #nullable enable
 public FeaturedStickersNotModified (int count)
{
 Count = count;
 
}
#nullable disable
        internal FeaturedStickersNotModified() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.featuredStickersNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
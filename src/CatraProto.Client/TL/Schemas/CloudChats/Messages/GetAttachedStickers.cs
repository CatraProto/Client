using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetAttachedStickers : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -866424884; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase Media { get; set; }

        
        #nullable enable
 public GetAttachedStickers (CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase media)
{
 Media = media;
 
}
#nullable disable
                
        internal GetAttachedStickers() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Media);

		}

		public void Deserialize(Reader reader)
		{
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase>();

		}
		
		public override string ToString()
		{
		    return "messages.getAttachedStickers";
		}
	}
}
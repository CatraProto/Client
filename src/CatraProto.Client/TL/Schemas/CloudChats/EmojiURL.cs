using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiURL : CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1519029347; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }


        #nullable enable
 public EmojiURL (string url)
{
 Url = url;
 
}
#nullable disable
        internal EmojiURL() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "emojiURL";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatOnlines : CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -264117680; }
        
[Newtonsoft.Json.JsonProperty("onlines")]
		public sealed override int Onlines { get; set; }


        #nullable enable
 public ChatOnlines (int onlines)
{
 Onlines = onlines;
 
}
#nullable disable
        internal ChatOnlines() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Onlines);

		}

		public override void Deserialize(Reader reader)
		{
			Onlines = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "chatOnlines";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
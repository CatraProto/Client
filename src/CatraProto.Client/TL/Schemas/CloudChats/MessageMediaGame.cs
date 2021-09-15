using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGame : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        public static int StaticConstructorId { get => -38694904; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("game")]
		public CatraProto.Client.TL.Schemas.CloudChats.GameBase Game { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Game);

		}

		public override void Deserialize(Reader reader)
		{
			Game = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GameBase>();

		}
				
		public override string ToString()
		{
		    return "messageMediaGame";
		}
	}
}
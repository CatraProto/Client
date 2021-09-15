using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotCommand : CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase
	{


        public static int StaticConstructorId { get => -1032140601; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("command")]
		public override string Command { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public override string Description { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Command);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Command = reader.Read<string>();
			Description = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "botCommand";
		}
	}
}
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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1032140601; }
        
[Newtonsoft.Json.JsonProperty("command")]
		public sealed override string Command { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public sealed override string Description { get; set; }


        #nullable enable
 public BotCommand (string command,string description)
{
 Command = command;
Description = description;
 
}
#nullable disable
        internal BotCommand() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
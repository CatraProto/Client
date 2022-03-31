using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInfo : CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 460632885; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public sealed override string Description { get; set; }

[Newtonsoft.Json.JsonProperty("commands")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }


        #nullable enable
 public BotInfo (long userId,string description,IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands)
{
 UserId = userId;
Description = description;
Commands = commands;
 
}
#nullable disable
        internal BotInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Description);
			writer.Write(Commands);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Description = reader.Read<string>();
			Commands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();

		}
		
		public override string ToString()
		{
		    return "botInfo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
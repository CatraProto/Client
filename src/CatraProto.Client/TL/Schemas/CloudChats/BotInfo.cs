using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInfo : CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase
	{


        public static int StaticConstructorId { get => -1729618630; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

[JsonPropertyName("commands")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Description);
			writer.Write(Commands);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Description = reader.Read<string>();
			Commands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();

		}
	}
}
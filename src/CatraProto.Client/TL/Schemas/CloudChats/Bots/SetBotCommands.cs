using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SetBotCommands : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2141370634; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("commands")]
		public IList<BotCommandBase> Commands { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Commands);

		}

		public void Deserialize(Reader reader)
		{
			Commands = reader.ReadVector<BotCommandBase>();
		}

		public override string ToString()
		{
			return "bots.setBotCommands";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SetBotCommands : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 85399130; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("scope")]
		public CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase Scope { get; set; }

[Newtonsoft.Json.JsonProperty("lang_code")]
		public string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("commands")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        
        #nullable enable
 public SetBotCommands (CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope,string langCode,IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands)
{
 Scope = scope;
LangCode = langCode;
Commands = commands;
 
}
#nullable disable
                
        internal SetBotCommands() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Scope);
			writer.Write(LangCode);
			writer.Write(Commands);

		}

		public void Deserialize(Reader reader)
		{
			Scope = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase>();
			LangCode = reader.Read<string>();
			Commands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();

		}
		
		public override string ToString()
		{
		    return "bots.setBotCommands";
		}
	}
}
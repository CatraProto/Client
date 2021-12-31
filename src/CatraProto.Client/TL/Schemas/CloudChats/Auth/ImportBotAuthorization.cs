using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportBotAuthorization : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1738800940; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("flags")]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("api_id")]
		public int ApiId { get; set; }

[Newtonsoft.Json.JsonProperty("api_hash")]
		public string ApiHash { get; set; }

[Newtonsoft.Json.JsonProperty("bot_auth_token")]
		public string BotAuthToken { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Flags);
			writer.Write(ApiId);
			writer.Write(ApiHash);
			writer.Write(BotAuthToken);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ApiId = reader.Read<int>();
			ApiHash = reader.Read<string>();
			BotAuthToken = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "auth.importBotAuthorization";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoggedOut : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOutBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FutureAuthToken = 1 << 0
		}

        public static int StaticConstructorId { get => -1012759713; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("future_auth_token")]
		public override byte[] FutureAuthToken { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FutureAuthToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FutureAuthToken);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FutureAuthToken = reader.Read<byte[]>();
			}


		}
				
		public override string ToString()
		{
		    return "auth.loggedOut";
		}
	}
}
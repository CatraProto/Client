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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1012759713; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("future_auth_token")]
		public sealed override byte[] FutureAuthToken { get; set; }


        
        public LoggedOut() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = FutureAuthToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
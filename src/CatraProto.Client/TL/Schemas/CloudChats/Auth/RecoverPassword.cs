using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class RecoverPassword : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NewSettings = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 923364464; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("code")]
		public string Code { get; set; }

[Newtonsoft.Json.JsonProperty("new_settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }


		public void UpdateFlags() 
		{
			Flags = NewSettings == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Code);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NewSettings);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Code = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NewSettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();
			}


		}
		
		public override string ToString()
		{
		    return "auth.recoverPassword";
		}
	}
}
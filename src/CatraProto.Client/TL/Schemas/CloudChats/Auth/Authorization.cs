using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class Authorization : CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SetupPasswordRequired = 1 << 1,
			OtherwiseReloginDays = 1 << 1,
			TmpSessions = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 872119224; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("setup_password_required")]
		public bool SetupPasswordRequired { get; set; }

[Newtonsoft.Json.JsonProperty("otherwise_relogin_days")]
		public int? OtherwiseReloginDays { get; set; }

[Newtonsoft.Json.JsonProperty("tmp_sessions")]
		public int? TmpSessions { get; set; }

[Newtonsoft.Json.JsonProperty("user")]
		public CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }


        #nullable enable
 public Authorization (CatraProto.Client.TL.Schemas.CloudChats.UserBase user)
{
 User = user;
 
}
#nullable disable
        internal Authorization() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = SetupPasswordRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = OtherwiseReloginDays == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TmpSessions == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(OtherwiseReloginDays.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TmpSessions.Value);
			}

			writer.Write(User);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SetupPasswordRequired = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				OtherwiseReloginDays = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TmpSessions = reader.Read<int>();
			}

			User = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "auth.authorization";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
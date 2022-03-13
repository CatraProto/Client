using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CodeSettings : CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			AllowFlashcall = 1 << 0,
			CurrentNumber = 1 << 1,
			AllowAppHash = 1 << 4,
			AllowMissedCall = 1 << 5,
			LogoutTokens = 1 << 6
		}

        public static int StaticConstructorId { get => -1973130814; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("allow_flashcall")]
		public sealed override bool AllowFlashcall { get; set; }

[Newtonsoft.Json.JsonProperty("current_number")]
		public sealed override bool CurrentNumber { get; set; }

[Newtonsoft.Json.JsonProperty("allow_app_hash")]
		public sealed override bool AllowAppHash { get; set; }

[Newtonsoft.Json.JsonProperty("allow_missed_call")]
		public sealed override bool AllowMissedCall { get; set; }

[Newtonsoft.Json.JsonProperty("logout_tokens")]
		public sealed override IList<byte[]> LogoutTokens { get; set; }


        
        public CodeSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = AllowFlashcall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CurrentNumber ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = AllowAppHash ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = AllowMissedCall ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = LogoutTokens == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(LogoutTokens);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			AllowFlashcall = FlagsHelper.IsFlagSet(Flags, 0);
			CurrentNumber = FlagsHelper.IsFlagSet(Flags, 1);
			AllowAppHash = FlagsHelper.IsFlagSet(Flags, 4);
			AllowMissedCall = FlagsHelper.IsFlagSet(Flags, 5);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				LogoutTokens = reader.ReadVector<byte[]>();
			}


		}
				
		public override string ToString()
		{
		    return "codeSettings";
		}
	}
}
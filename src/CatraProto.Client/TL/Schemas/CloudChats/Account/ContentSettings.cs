using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ContentSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			SensitiveEnabled = 1 << 0,
			SensitiveCanChange = 1 << 1
		}

        public static int StaticConstructorId { get => 1474462241; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("sensitive_enabled")]
		public override bool SensitiveEnabled { get; set; }

[Newtonsoft.Json.JsonProperty("sensitive_can_change")]
		public override bool SensitiveCanChange { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SensitiveCanChange ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
			SensitiveCanChange = FlagsHelper.IsFlagSet(Flags, 1);

		}
				
		public override string ToString()
		{
		    return "account.contentSettings";
		}
	}
}
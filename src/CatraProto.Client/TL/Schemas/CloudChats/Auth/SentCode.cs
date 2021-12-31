using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCode : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextType = 1 << 1,
			Timeout = 1 << 2
		}

        public static int StaticConstructorId { get => 1577067778; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public override CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("phone_code_hash")]
		public override string PhoneCodeHash { get; set; }

[Newtonsoft.Json.JsonProperty("next_type")]
		public override CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public override int? Timeout { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = NextType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);
			writer.Write(PhoneCodeHash);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NextType);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Timeout.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase>();
			PhoneCodeHash = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NextType = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Timeout = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "auth.sentCode";
		}
	}
}
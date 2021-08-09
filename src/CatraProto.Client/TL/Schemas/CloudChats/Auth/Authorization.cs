using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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
			TmpSessions = 1 << 0
		}

        public static int StaticConstructorId { get => -855308010; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("tmp_sessions")]
		public int? TmpSessions { get; set; }

[JsonPropertyName("user")]
		public CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = TmpSessions == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TmpSessions.Value);
			}

			writer.Write(User);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TmpSessions = reader.Read<int>();
			}

			User = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}
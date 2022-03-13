using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class ToggleGroupCallSettings : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ResetInviteHash = 1 << 1,
			JoinMuted = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1958458429; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("reset_invite_hash")]
		public bool ResetInviteHash { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("join_muted")]
		public bool? JoinMuted { get; set; }

        
        #nullable enable
 public ToggleGroupCallSettings (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
{
 Call = call;
 
}
#nullable disable
                
        internal ToggleGroupCallSettings() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = ResetInviteHash ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = JoinMuted == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Call);
			writer.Write(JoinMuted.Value);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ResetInviteHash = FlagsHelper.IsFlagSet(Flags, 1);
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
			JoinMuted = reader.Read<bool>();
			}


		}
		
		public override string ToString()
		{
		    return "phone.toggleGroupCallSettings";
		}
	}
}
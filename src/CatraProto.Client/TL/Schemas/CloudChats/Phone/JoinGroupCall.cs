using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class JoinGroupCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Muted = 1 << 0,
			VideoStopped = 1 << 2,
			InviteHash = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1322057861; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("muted")]
		public bool Muted { get; set; }

[Newtonsoft.Json.JsonProperty("video_stopped")]
		public bool VideoStopped { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("join_as")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase JoinAs { get; set; }

[Newtonsoft.Json.JsonProperty("invite_hash")]
		public string InviteHash { get; set; }

[Newtonsoft.Json.JsonProperty("params")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }


		public void UpdateFlags() 
		{
			Flags = Muted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = VideoStopped ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = InviteHash == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Call);
			writer.Write(JoinAs);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(InviteHash);
			}

			writer.Write(Params);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Muted = FlagsHelper.IsFlagSet(Flags, 0);
			VideoStopped = FlagsHelper.IsFlagSet(Flags, 2);
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			JoinAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				InviteHash = reader.Read<string>();
			}

			Params = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "phone.joinGroupCall";
		}
	}
}
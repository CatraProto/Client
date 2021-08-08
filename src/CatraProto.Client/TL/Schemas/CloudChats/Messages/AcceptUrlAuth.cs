using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AcceptUrlAuth : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			WriteAllowed = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -148247912; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UrlAuthResultBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("write_allowed")]
		public bool WriteAllowed { get; set; }

[JsonPropertyName("peer")]
		public InputPeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("button_id")]
		public int ButtonId { get; set; }


		public void UpdateFlags() 
		{
			Flags = WriteAllowed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ButtonId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			WriteAllowed = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			ButtonId = reader.Read<int>();

		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetTyping : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			TopMsgId = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1486110434; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[JsonPropertyName("top_msg_id")]
		public int? TopMsgId { get; set; }

[JsonPropertyName("action")]
		public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


		public void UpdateFlags() 
		{
			Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TopMsgId.Value);
			}

			writer.Write(Action);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TopMsgId = reader.Read<int>();
			}

			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();

		}
	}
}
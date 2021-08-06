using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetBotCallbackAnswer : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Game = 1 << 1,
			Data = 1 << 0,
			Password = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1824339449; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("game")]
		public bool Game { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("data")]
		public byte[] Data { get; set; }

[JsonPropertyName("password")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }


		public void UpdateFlags() 
		{
			Flags = Game ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Password == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(MsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Data);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Password);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Game = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			MsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Data = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
			}


		}
	}
}
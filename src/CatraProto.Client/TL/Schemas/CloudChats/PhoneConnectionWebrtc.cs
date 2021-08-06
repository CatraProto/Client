using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneConnectionWebrtc : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Turn = 1 << 0,
			Stun = 1 << 1
		}

        public static int StaticConstructorId { get => 1667228533; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("turn")]
		public bool Turn { get; set; }

[JsonPropertyName("stun")]
		public bool Stun { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("ip")]
		public override string Ip { get; set; }

[JsonPropertyName("ipv6")]
		public override string Ipv6 { get; set; }

[JsonPropertyName("port")]
		public override int Port { get; set; }

[JsonPropertyName("username")]
		public string Username { get; set; }

[JsonPropertyName("password")]
		public string Password { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Turn ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Stun ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Ip);
			writer.Write(Ipv6);
			writer.Write(Port);
			writer.Write(Username);
			writer.Write(Password);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Turn = FlagsHelper.IsFlagSet(Flags, 0);
			Stun = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<long>();
			Ip = reader.Read<string>();
			Ipv6 = reader.Read<string>();
			Port = reader.Read<int>();
			Username = reader.Read<string>();
			Password = reader.Read<string>();

		}
	}
}
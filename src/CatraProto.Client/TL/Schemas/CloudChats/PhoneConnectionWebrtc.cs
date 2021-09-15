using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

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
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("turn")]
		public bool Turn { get; set; }

[Newtonsoft.Json.JsonProperty("stun")]
		public bool Stun { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public override string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("ipv6")]
		public override string Ipv6 { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public override int Port { get; set; }

[Newtonsoft.Json.JsonProperty("username")]
		public string Username { get; set; }

[Newtonsoft.Json.JsonProperty("password")]
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
				
		public override string ToString()
		{
		    return "phoneConnectionWebrtc";
		}
	}
}
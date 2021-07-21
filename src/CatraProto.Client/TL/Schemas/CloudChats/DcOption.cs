using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DcOption : CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Ipv6 = 1 << 0,
			MediaOnly = 1 << 1,
			TcpoOnly = 1 << 2,
			Cdn = 1 << 3,
			Static = 1 << 4,
			Secret = 1 << 10
		}

        public static int StaticConstructorId { get => 414687501; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("ipv6")]
		public override bool Ipv6 { get; set; }

[JsonPropertyName("media_only")]
		public override bool MediaOnly { get; set; }

[JsonPropertyName("tcpo_only")]
		public override bool TcpoOnly { get; set; }

[JsonPropertyName("cdn")]
		public override bool Cdn { get; set; }

[JsonPropertyName("static")]
		public override bool Static { get; set; }

[JsonPropertyName("id")]
		public override int Id { get; set; }

[JsonPropertyName("ip_address")]
		public override string IpAddress { get; set; }

[JsonPropertyName("port")]
		public override int Port { get; set; }

[JsonPropertyName("secret")]
		public override byte[] Secret { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Ipv6 ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = MediaOnly ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = TcpoOnly ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Cdn ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Static ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Secret == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(IpAddress);
			writer.Write(Port);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(Secret);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Ipv6 = FlagsHelper.IsFlagSet(Flags, 0);
			MediaOnly = FlagsHelper.IsFlagSet(Flags, 1);
			TcpoOnly = FlagsHelper.IsFlagSet(Flags, 2);
			Cdn = FlagsHelper.IsFlagSet(Flags, 3);
			Static = FlagsHelper.IsFlagSet(Flags, 4);
			Id = reader.Read<int>();
			IpAddress = reader.Read<string>();
			Port = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				Secret = reader.Read<byte[]>();
			}


		}
	}
}
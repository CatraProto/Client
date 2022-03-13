using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("ipv6")]
		public sealed override bool Ipv6 { get; set; }

[Newtonsoft.Json.JsonProperty("media_only")]
		public sealed override bool MediaOnly { get; set; }

[Newtonsoft.Json.JsonProperty("tcpo_only")]
		public sealed override bool TcpoOnly { get; set; }

[Newtonsoft.Json.JsonProperty("cdn")]
		public sealed override bool Cdn { get; set; }

[Newtonsoft.Json.JsonProperty("static")]
		public sealed override bool Static { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("ip_address")]
		public sealed override string IpAddress { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public sealed override int Port { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public sealed override byte[] Secret { get; set; }


        #nullable enable
 public DcOption (int id,string ipAddress,int port)
{
 Id = id;
IpAddress = ipAddress;
Port = port;
 
}
#nullable disable
        internal DcOption() 
        {
        }
		
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
writer.Write(ConstructorId);
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
				
		public override string ToString()
		{
		    return "dcOption";
		}
	}
}
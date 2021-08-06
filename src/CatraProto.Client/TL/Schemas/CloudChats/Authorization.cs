using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Authorization : CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Current = 1 << 0,
			OfficialApp = 1 << 1,
			PasswordPending = 1 << 2
		}

        public static int StaticConstructorId { get => -1392388579; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("current")]
		public override bool Current { get; set; }

[JsonPropertyName("official_app")]
		public override bool OfficialApp { get; set; }

[JsonPropertyName("password_pending")]
		public override bool PasswordPending { get; set; }

[JsonPropertyName("hash")]
		public override long Hash { get; set; }

[JsonPropertyName("device_model")]
		public override string DeviceModel { get; set; }

[JsonPropertyName("platform")]
		public override string Platform { get; set; }

[JsonPropertyName("system_version")]
		public override string SystemVersion { get; set; }

[JsonPropertyName("api_id")]
		public override int ApiId { get; set; }

[JsonPropertyName("app_name")]
		public override string AppName { get; set; }

[JsonPropertyName("app_version")]
		public override string AppVersion { get; set; }

[JsonPropertyName("date_created")]
		public override int DateCreated { get; set; }

[JsonPropertyName("date_active")]
		public override int DateActive { get; set; }

[JsonPropertyName("ip")]
		public override string Ip { get; set; }

[JsonPropertyName("country")]
		public override string Country { get; set; }

[JsonPropertyName("region")]
		public override string Region { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Current ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = OfficialApp ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = PasswordPending ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Hash);
			writer.Write(DeviceModel);
			writer.Write(Platform);
			writer.Write(SystemVersion);
			writer.Write(ApiId);
			writer.Write(AppName);
			writer.Write(AppVersion);
			writer.Write(DateCreated);
			writer.Write(DateActive);
			writer.Write(Ip);
			writer.Write(Country);
			writer.Write(Region);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Current = FlagsHelper.IsFlagSet(Flags, 0);
			OfficialApp = FlagsHelper.IsFlagSet(Flags, 1);
			PasswordPending = FlagsHelper.IsFlagSet(Flags, 2);
			Hash = reader.Read<long>();
			DeviceModel = reader.Read<string>();
			Platform = reader.Read<string>();
			SystemVersion = reader.Read<string>();
			ApiId = reader.Read<int>();
			AppName = reader.Read<string>();
			AppVersion = reader.Read<string>();
			DateCreated = reader.Read<int>();
			DateActive = reader.Read<int>();
			Ip = reader.Read<string>();
			Country = reader.Read<string>();
			Region = reader.Read<string>();

		}
	}
}
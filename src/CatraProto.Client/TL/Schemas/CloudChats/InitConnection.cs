using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InitConnection : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Proxy = 1 << 0,
			Params = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1043505495; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("api_id")]
		public int ApiId { get; set; }

[JsonPropertyName("device_model")]
		public string DeviceModel { get; set; }

[JsonPropertyName("system_version")]
		public string SystemVersion { get; set; }

[JsonPropertyName("app_version")]
		public string AppVersion { get; set; }

[JsonPropertyName("system_lang_code")]
		public string SystemLangCode { get; set; }

[JsonPropertyName("lang_pack")]
		public string LangPack { get; set; }

[JsonPropertyName("lang_code")]
		public string LangCode { get; set; }

[JsonPropertyName("proxy")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase Proxy { get; set; }

[JsonPropertyName("params")]
		public CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Params { get; set; }

[JsonPropertyName("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{
			Flags = Proxy == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Params == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ApiId);
			writer.Write(DeviceModel);
			writer.Write(SystemVersion);
			writer.Write(AppVersion);
			writer.Write(SystemLangCode);
			writer.Write(LangPack);
			writer.Write(LangCode);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Proxy);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Params);
			}

			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ApiId = reader.Read<int>();
			DeviceModel = reader.Read<string>();
			SystemVersion = reader.Read<string>();
			AppVersion = reader.Read<string>();
			SystemLangCode = reader.Read<string>();
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Proxy = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Params = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
			}

			Query = reader.Read<IObject>();

		}
	}
}
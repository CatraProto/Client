using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetStrings : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -269862909; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(LangPackStringBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("lang_pack")]
		public string LangPack { get; set; }

[JsonPropertyName("lang_code")]
		public string LangCode { get; set; }

[JsonPropertyName("keys")]
		public IList<string> Keys { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangPack);
			writer.Write(LangCode);
			writer.Write(Keys);

		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();
			LangCode = reader.Read<string>();
			Keys = reader.ReadVector<string>();
		}

		public override string ToString()
		{
			return "langpack.getStrings";
		}
	}
}
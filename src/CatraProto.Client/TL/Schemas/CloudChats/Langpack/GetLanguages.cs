using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
	public partial class GetLanguages : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1120311183; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(LangPackLanguageBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("lang_pack")]
		public string LangPack { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangPack);

		}

		public void Deserialize(Reader reader)
		{
			LangPack = reader.Read<string>();

		}
	}
}
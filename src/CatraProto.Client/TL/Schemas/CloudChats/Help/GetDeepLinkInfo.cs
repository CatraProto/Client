using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetDeepLinkInfo : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1072547679; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(DeepLinkInfoBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("path")]
		public string Path { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Path);

		}

		public void Deserialize(Reader reader)
		{
			Path = reader.Read<string>();
		}

		public override string ToString()
		{
			return "help.getDeepLinkInfo";
		}
	}
}
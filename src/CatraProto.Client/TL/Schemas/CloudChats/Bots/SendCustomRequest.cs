using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SendCustomRequest : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1440257555; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(DataJSONBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("custom_method")]
		public string CustomMethod { get; set; }

[JsonPropertyName("params")]
		public DataJSONBase Params { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(CustomMethod);
			writer.Write(Params);

		}

		public void Deserialize(Reader reader)
		{
			CustomMethod = reader.Read<string>();
			Params = reader.Read<DataJSONBase>();
		}

		public override string ToString()
		{
			return "bots.sendCustomRequest";
		}
	}
}
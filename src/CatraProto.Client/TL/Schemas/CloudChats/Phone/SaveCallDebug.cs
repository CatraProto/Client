using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SaveCallDebug : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 662363518; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("peer")]
		public InputPhoneCallBase Peer { get; set; }

[JsonPropertyName("debug")]
		public DataJSONBase Debug { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Debug);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPhoneCallBase>();
			Debug = reader.Read<DataJSONBase>();
		}

		public override string ToString()
		{
			return "phone.saveCallDebug";
		}
	}
}
using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class GetFutureSalts : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1188971260; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(FutureSaltsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("num")]
		public int Num { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);

		}

		public void Deserialize(Reader reader)
		{
			Num = reader.Read<int>();
		}

		public override string ToString()
		{
			return "get_future_salts";
		}
	}
}
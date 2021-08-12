using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithoutUpdates : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1080796745; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Query = reader.Read<IObject>();
		}

		public override string ToString()
		{
			return "invokeWithoutUpdates";
		}
	}
}
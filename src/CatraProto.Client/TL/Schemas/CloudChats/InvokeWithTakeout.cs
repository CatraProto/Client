using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithTakeout : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1398145746; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("takeout_id")]
		public long TakeoutId { get; set; }

[JsonPropertyName("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TakeoutId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			TakeoutId = reader.Read<long>();
			Query = reader.Read<IObject>();

		}
	}
}
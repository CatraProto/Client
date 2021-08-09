using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithMessagesRange : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 911373810; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("range")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase Range { get; set; }

[JsonPropertyName("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Range);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Range = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
			Query = reader.Read<IObject>();

		}
	}
}
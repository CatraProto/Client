using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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
		Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("range")]
		public MessageRangeBase Range { get; set; }

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
			Range = reader.Read<MessageRangeBase>();
			Query = reader.Read<IObject>();

		}
	}
}
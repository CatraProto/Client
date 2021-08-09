using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeAfterMsg : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -878758099; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("msg_id")]
		public long MsgId { get; set; }

[JsonPropertyName("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			Query = reader.Read<IObject>();

		}
	}
}
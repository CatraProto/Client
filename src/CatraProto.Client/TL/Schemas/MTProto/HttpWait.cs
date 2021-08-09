using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class HttpWait : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1835453025; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("max_delay")]
		public int MaxDelay { get; set; }

[JsonPropertyName("wait_after")]
		public int WaitAfter { get; set; }

[JsonPropertyName("max_wait")]
		public int MaxWait { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxDelay);
			writer.Write(WaitAfter);
			writer.Write(MaxWait);

		}

		public void Deserialize(Reader reader)
		{
			MaxDelay = reader.Read<int>();
			WaitAfter = reader.Read<int>();
			MaxWait = reader.Read<int>();

		}
	}
}
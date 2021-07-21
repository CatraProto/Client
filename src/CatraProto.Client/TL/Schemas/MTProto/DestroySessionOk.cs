using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionOk : CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase
	{


        public static int StaticConstructorId { get => -501201412; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("session_id")]
		public override long SessionId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SessionId);

		}

		public override void Deserialize(Reader reader)
		{
			SessionId = reader.Read<long>();

		}
	}
}
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcError : CatraProto.Client.TL.Schemas.MTProto.RpcErrorBase
	{


        public static int StaticConstructorId { get => 558156313; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("error_code")]
		public override int ErrorCode { get; set; }

[JsonPropertyName("error_message")]
		public override string ErrorMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ErrorCode);
			writer.Write(ErrorMessage);

		}

		public override void Deserialize(Reader reader)
		{
			ErrorCode = reader.Read<int>();
			ErrorMessage = reader.Read<string>();

		}
	}
}
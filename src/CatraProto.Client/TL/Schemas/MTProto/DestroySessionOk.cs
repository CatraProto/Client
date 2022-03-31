using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class DestroySessionOk : CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -501201412; }
        
[Newtonsoft.Json.JsonProperty("session_id")]
		public sealed override long SessionId { get; set; }


        #nullable enable
 public DestroySessionOk (long sessionId)
{
 SessionId = sessionId;
 
}
#nullable disable
        internal DestroySessionOk() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(SessionId);

		}

		public override void Deserialize(Reader reader)
		{
			SessionId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "destroy_session_ok";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
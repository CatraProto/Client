using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgCopy : CatraProto.Client.TL.Schemas.MTProto.MessageCopyBase
	{


        public static int StaticConstructorId { get => -530561358; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("orig_message")]
		public sealed override CatraProto.Client.TL.Schemas.MTProto.MessageBase OrigMessage { get; set; }


        #nullable enable
 public MsgCopy (CatraProto.Client.TL.Schemas.MTProto.MessageBase origMessage)
{
 OrigMessage = origMessage;
 
}
#nullable disable
        internal MsgCopy() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(OrigMessage);

		}

		public override void Deserialize(Reader reader)
		{
			OrigMessage = reader.Read<CatraProto.Client.TL.Schemas.MTProto.MessageBase>();

		}
				
		public override string ToString()
		{
		    return "msg_copy";
		}
	}
}
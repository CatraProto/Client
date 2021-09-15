using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : CatraProto.Client.TL.Schemas.MTProto.MessageContainerBase
	{


        public static int StaticConstructorId { get => 1945237724; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("messages")]
		public override IList<CatraProto.Client.TL.Schemas.MTProto.Message> Messages { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			Messages = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.MTProto.Deserializers.MsgContainerDeserializer>(), true).Cast<CatraProto.Client.TL.Schemas.MTProto.Message>().ToList();

		}
				
		public override string ToString()
		{
		    return "msg_container";
		}
	}
}
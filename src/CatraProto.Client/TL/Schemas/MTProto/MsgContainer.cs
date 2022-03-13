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
		public sealed override IList<CatraProto.Client.TL.Schemas.MTProto.MessageBase> Messages { get; set; }


        #nullable enable
 public MsgContainer (IList<CatraProto.Client.TL.Schemas.MTProto.MessageBase> messages)
{
 Messages = messages;
 
}
#nullable disable
        internal MsgContainer() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			Messages = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.MTProto.Deserializers.MsgContainerDeserializer>(CatraProto.Client.TL.Schemas.MergedProvider.Singleton), true).Cast<CatraProto.Client.TL.Schemas.MTProto.MessageBase>().ToList();

		}
				
		public override string ToString()
		{
		    return "msg_container";
		}
	}
}
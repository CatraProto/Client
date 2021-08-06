using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : CatraProto.Client.TL.Schemas.MTProto.MessageContainerBase
	{


        public static int StaticConstructorId { get => 1945237724; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("messages")]
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
			Messages = reader.ReadVector(new CatraProto.TL.ObjectDeserializers.NakedObjectVectorDeserializer<CatraProto.Client.TL.Schemas.MTProto.Message>(), true);

		}
	}
}
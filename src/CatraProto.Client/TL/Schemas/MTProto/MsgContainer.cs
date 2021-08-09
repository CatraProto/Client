using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.TL;
using CatraProto.TL.ObjectDeserializers;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : MessageContainerBase
	{


        public static int StaticConstructorId { get => 1945237724; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("messages")] public override IList<Message> Messages { get; set; }

        
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
			Messages = reader.ReadVector(new NakedObjectVectorDeserializer<MsgContainerDeserializer>(), true).Cast<Message>().ToList();

		}
	}
}
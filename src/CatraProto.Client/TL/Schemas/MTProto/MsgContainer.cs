using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.ObjectDeserializers;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : MessageContainerBase
	{


        public static int ConstructorId { get; } = 1945237724;
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
			Messages = reader.ReadVector(new NakedObjectDeserializer<Message>(), true);

		}
	}
}
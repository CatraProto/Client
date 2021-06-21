using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : MessageContainerBase
	{


        public static int ConstructorId { get; } = 1945237724;
		public override IList<CatraProto.Client.TL.Schemas.MTProto.MessageBase> Messages { get; set; }

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
			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.MTProto.MessageBase>(() => {var instance = (CatraProto.Client.TL.Schemas.MTProto.MessageBase)new CatraProto.Client.TL.Schemas.MTProto.Message(); instance.Deserialize(reader); return instance;});

		}
	}
}
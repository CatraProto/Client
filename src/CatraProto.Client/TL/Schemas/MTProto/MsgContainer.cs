using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;


namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : IMethod
	{


        public static int ConstructorId { get; } = 1945237724;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.MsgContainer);
		public bool IsVector { get; init; } = false;
		public IList<MessageBase> Messages { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Messages);

		}

		public void Deserialize(Reader reader)
		{
			Messages = reader.ReadVector<MessageBase>();

		}
	}
}
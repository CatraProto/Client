using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgContainer : IMethod<MessageContainerBase>
	{


        public static int ConstructorId { get; } = 1945237724;

		public Type Type { get; init; } = typeof(MsgContainer);
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
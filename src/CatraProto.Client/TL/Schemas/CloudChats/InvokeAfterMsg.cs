using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeAfterMsg : IMethod<IObject>
	{


        public static int ConstructorId { get; } = -878758099;

		public Type Type { get; init; } = typeof(InvokeAfterMsg);
		public bool IsVector { get; init; } = false;
		public long MsgId { get; set; }
		public IObject Query { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			Query = reader.Read<IObject>();

		}
	}
}
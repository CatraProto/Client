using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithMessagesRange : IMethod<IObject>
	{


        public static int ConstructorId { get; } = 911373810;

		public Type Type { get; init; } = typeof(InvokeWithMessagesRange);
		public bool IsVector { get; init; } = false;
		public MessageRangeBase Range { get; set; }
		public IObject Query { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Range);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Range = reader.Read<MessageRangeBase>();
			Query = reader.Read<IObject>();

		}
	}
}
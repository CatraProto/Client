using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithMessagesRange : IMethod
	{


        public static int ConstructorId { get; } = 911373810;

		public System.Type Type { get; init; } = typeof(IObject);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase Range { get; set; }
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
			Range = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
			Query = reader.Read<IObject>();

		}
	}
}
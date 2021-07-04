using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSplitRanges : IMethod
	{


        public static int ConstructorId { get; } = 486505992;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}
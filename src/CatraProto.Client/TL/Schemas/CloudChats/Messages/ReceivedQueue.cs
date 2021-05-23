using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReceivedQueue : IMethod
	{


        public static int ConstructorId { get; } = 1436924774;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedQueue);
		public bool IsVector { get; init; } = false;
		public int MaxQts { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxQts);

		}

		public void Deserialize(Reader reader)
		{
			MaxQts = reader.Read<int>();

		}
	}
}
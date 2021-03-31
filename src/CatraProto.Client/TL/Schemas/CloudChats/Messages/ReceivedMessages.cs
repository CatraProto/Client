using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReceivedMessages : IMethod<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>
	{


        public static int ConstructorId { get; } = 94983360;

		public int MaxId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxId);

		}

		public void Deserialize(Reader reader)
		{
			MaxId = reader.Read<int>();

		}
	}
}
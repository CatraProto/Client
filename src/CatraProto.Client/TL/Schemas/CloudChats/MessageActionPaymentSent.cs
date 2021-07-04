using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPaymentSent : MessageActionBase
	{


        public static int ConstructorId { get; } = 1080663248;
		public string Currency { get; set; }
		public long TotalAmount { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Currency);
			writer.Write(TotalAmount);

		}

		public override void Deserialize(Reader reader)
		{
			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();

		}
	}
}
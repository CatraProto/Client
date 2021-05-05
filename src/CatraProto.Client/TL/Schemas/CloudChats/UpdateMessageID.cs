using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessageID : UpdateBase
	{


        public static int ConstructorId { get; } = 1318109142;
		public int Id { get; set; }
		public long RandomId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(RandomId);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			RandomId = reader.Read<long>();

		}
	}
}
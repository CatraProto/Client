using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Contact : ContactBase
	{


        public static int ConstructorId { get; } = -116274796;
		public override int UserId { get; set; }
		public override bool Mutual { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Mutual);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Mutual = reader.Read<bool>();

		}
	}
}
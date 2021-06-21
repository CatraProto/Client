using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ContactStatus : ContactStatusBase
	{


        public static int ConstructorId { get; } = -748155807;
		public override int UserId { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Status);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Status = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase>();

		}
	}
}
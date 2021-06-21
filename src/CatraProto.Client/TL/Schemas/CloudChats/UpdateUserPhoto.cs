using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhoto : UpdateBase
	{


        public static int ConstructorId { get; } = -1791935732;
		public int UserId { get; set; }
		public int Date { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase Photo { get; set; }
		public bool Previous { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Date);
			writer.Write(Photo);
			writer.Write(Previous);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Date = reader.Read<int>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase>();
			Previous = reader.Read<bool>();

		}
	}
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class TmpPassword : TmpPasswordBase
	{


        public static int ConstructorId { get; } = -614138572;
		public override byte[] PTmpPassword { get; set; }
		public override int ValidUntil { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PTmpPassword);
			writer.Write(ValidUntil);

		}

		public override void Deserialize(Reader reader)
		{
			PTmpPassword = reader.Read<byte[]>();
			ValidUntil = reader.Read<int>();

		}
	}
}
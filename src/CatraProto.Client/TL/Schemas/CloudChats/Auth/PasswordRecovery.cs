using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class PasswordRecovery : PasswordRecoveryBase
	{


        public static int ConstructorId { get; } = 326715557;
		public override string EmailPattern { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(EmailPattern);

		}

		public override void Deserialize(Reader reader)
		{
			EmailPattern = reader.Read<string>();

		}
	}
}
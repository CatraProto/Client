using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyKeyPhoneP2P : PrivacyKeyBase
	{


        public static int ConstructorId { get; } = 961092808;

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
	}
}
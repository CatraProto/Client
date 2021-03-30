using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyKeyChatInvite : InputPrivacyKeyBase
	{


        public static int ConstructorId { get; } = -1107622874;

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
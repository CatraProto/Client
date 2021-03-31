using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAutoDownloadSettings : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>
	{


        public static int ConstructorId { get; } = 1457130303;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}
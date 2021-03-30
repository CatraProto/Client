using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetGlobalPrivacySettings : IMethod<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>
	{


        public static int ConstructorId { get; } = -349483786;


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
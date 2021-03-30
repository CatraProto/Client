using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SendChangePhoneCode : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>
	{


        public static int ConstructorId { get; } = -2108208411;

		public string PhoneNumber { get; set; }
		public CodeSettingsBase Settings { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneNumber);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			PhoneNumber = reader.Read<string>();
			Settings = reader.Read<CodeSettingsBase>();

		}
	}
}
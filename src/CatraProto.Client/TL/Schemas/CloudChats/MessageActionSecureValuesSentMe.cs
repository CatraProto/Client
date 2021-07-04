using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSecureValuesSentMe : MessageActionBase
	{


        public static int ConstructorId { get; } = 455635795;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Values);
			writer.Write(Credentials);

		}

		public override void Deserialize(Reader reader)
		{
			Values = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			Credentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();

		}
	}
}
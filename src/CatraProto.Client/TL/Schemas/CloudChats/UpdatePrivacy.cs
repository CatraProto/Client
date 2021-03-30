using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePrivacy : UpdateBase
	{


        public static int ConstructorId { get; } = -298113238;
		public PrivacyKeyBase Key { get; set; }
		public IList<PrivacyRuleBase> Rules { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Rules);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<PrivacyKeyBase>();
			Rules = reader.ReadVector<PrivacyRuleBase>();

		}
	}
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorFiles : SecureValueErrorBase
	{


        public static int ConstructorId { get; } = 1717706985;
		public override SecureValueTypeBase Type { get; set; }
		public IList<byte[]> FileHash { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(FileHash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<SecureValueTypeBase>();
			FileHash = reader.ReadVector<byte[]>();
			Text = reader.Read<string>();

		}
	}
}
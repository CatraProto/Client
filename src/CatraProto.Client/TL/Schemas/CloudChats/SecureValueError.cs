using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueError : SecureValueErrorBase
	{


        public static int ConstructorId { get; } = -2036501105;
		public override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }
		public byte[] Hash { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Hash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			Hash = reader.Read<byte[]>();
			Text = reader.Read<string>();

		}
	}
}
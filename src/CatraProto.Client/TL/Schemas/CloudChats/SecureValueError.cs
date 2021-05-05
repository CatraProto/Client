using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueError : SecureValueErrorBase
	{


        public static int ConstructorId { get; } = -2036501105;
		public override SecureValueTypeBase Type { get; set; }
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
			Type = reader.Read<SecureValueTypeBase>();
			Hash = reader.Read<byte[]>();
			Text = reader.Read<string>();

		}
	}
}
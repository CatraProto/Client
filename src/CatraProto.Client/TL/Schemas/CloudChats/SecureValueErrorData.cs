using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorData : SecureValueErrorBase
	{


        public static int ConstructorId { get; } = -391902247;
		public override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }
		public byte[] DataHash { get; set; }
		public string Field { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(DataHash);
			writer.Write(Field);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			DataHash = reader.Read<byte[]>();
			Field = reader.Read<string>();
			Text = reader.Read<string>();

		}
	}
}
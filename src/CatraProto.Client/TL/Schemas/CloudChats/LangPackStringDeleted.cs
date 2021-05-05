using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackStringDeleted : LangPackStringBase
	{


        public static int ConstructorId { get; } = 695856818;
		public override string Key { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();

		}
	}
}
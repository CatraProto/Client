using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveTheme : IMethod
	{


        public static int ConstructorId { get; } = -229175188;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }
		public bool Unsave { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Theme);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			Unsave = reader.Read<bool>();

		}
	}
}
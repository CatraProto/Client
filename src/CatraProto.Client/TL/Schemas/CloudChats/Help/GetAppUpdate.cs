using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class GetAppUpdate : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase>
	{


        public static int ConstructorId { get; } = 1378703997;

		public string Source { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Source);

		}

		public void Deserialize(Reader reader)
		{
			Source = reader.Read<string>();

		}
	}
}
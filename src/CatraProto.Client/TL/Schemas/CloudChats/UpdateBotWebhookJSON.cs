using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotWebhookJSON : UpdateBase
	{


        public static int ConstructorId { get; } = -2095595325;
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
	}
}
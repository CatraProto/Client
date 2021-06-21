using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
	{


        public static int ConstructorId { get; } = -1462213465;
		public override string Id { get; set; }
		public string Type { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Photo { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Type);
			writer.Write(Photo);
			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
			SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();

		}
	}
}
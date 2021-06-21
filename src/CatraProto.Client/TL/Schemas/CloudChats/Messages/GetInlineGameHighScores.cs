using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetInlineGameHighScores : IMethod
	{


        public static int ConstructorId { get; } = 258170395;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase Id { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
	}
}
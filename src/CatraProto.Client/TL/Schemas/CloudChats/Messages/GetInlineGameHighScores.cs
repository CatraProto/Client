using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetInlineGameHighScores : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>
	{


        public static int ConstructorId { get; } = 258170395;

		public InputBotInlineMessageIDBase Id { get; set; }
		public InputUserBase UserId { get; set; }

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
			Id = reader.Read<InputBotInlineMessageIDBase>();
			UserId = reader.Read<InputUserBase>();

		}
	}
}
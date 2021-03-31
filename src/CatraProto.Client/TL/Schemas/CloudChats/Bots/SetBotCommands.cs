using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SetBotCommands : IMethod<bool>
	{


        public static int ConstructorId { get; } = -2141370634;

		public IList<BotCommandBase> Commands { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Commands);

		}

		public void Deserialize(Reader reader)
		{
			Commands = reader.ReadVector<BotCommandBase>();

		}
	}
}
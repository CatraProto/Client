using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatMigrateTo : MessageActionBase
	{


        public static int ConstructorId { get; } = 1371385889;
		public int ChannelId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();

		}
	}
}
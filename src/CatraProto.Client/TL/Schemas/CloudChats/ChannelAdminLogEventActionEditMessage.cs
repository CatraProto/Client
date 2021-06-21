using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventActionBase
	{


        public static int ConstructorId { get; } = 1889215493;
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase PrevMessage { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase NewMessage { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevMessage);
			writer.Write(NewMessage);

		}

		public override void Deserialize(Reader reader)
		{
			PrevMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			NewMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();

		}
	}
}
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetFullChannel : IMethod
	{


        public static int ConstructorId { get; } = 141781513;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();

		}
	}
}
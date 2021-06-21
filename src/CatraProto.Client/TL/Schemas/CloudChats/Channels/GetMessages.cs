using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetMessages : IMethod
	{


        public static int ConstructorId { get; } = -1383294429;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase>();

		}
	}
}
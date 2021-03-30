using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetMessages : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>
	{


        public static int ConstructorId { get; } = -1383294429;

		public InputChannelBase Channel { get; set; }
		public IList<InputMessageBase> Id { get; set; }

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
			Channel = reader.Read<InputChannelBase>();
			Id = reader.ReadVector<InputMessageBase>();

		}
	}
}
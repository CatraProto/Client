using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class DeleteMessages : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>
	{


        public static int ConstructorId { get; } = -2067661490;

		public InputChannelBase Channel { get; set; }
		public IList<int> Id { get; set; }

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
			Id = reader.ReadVector<int>();

		}
	}
}
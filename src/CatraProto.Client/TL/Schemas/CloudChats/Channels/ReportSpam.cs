using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ReportSpam : IMethod<bool>
	{


        public static int ConstructorId { get; } = -32999408;

		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }
		public IList<int> Id { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
			Id = reader.ReadVector<int>();

		}
	}
}
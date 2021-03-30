using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetParticipants : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>
	{


        public static int ConstructorId { get; } = 306054633;

		public InputChannelBase Channel { get; set; }
		public ChannelParticipantsFilterBase Filter { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }
		public int Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Filter);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			Filter = reader.Read<ChannelParticipantsFilterBase>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}
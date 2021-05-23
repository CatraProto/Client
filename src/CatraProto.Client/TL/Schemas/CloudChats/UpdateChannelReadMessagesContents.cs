using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelReadMessagesContents : UpdateBase
	{


        public static int ConstructorId { get; } = -1987495099;
		public int ChannelId { get; set; }
		public IList<int> Messages { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Messages = reader.ReadVector<int>();

		}
	}
}
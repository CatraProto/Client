using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class UpdateUsername : IMethod
	{


        public static int ConstructorId { get; } = 890549214;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }
		public string Username { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Username);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Username = reader.Read<string>();

		}
	}
}
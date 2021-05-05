using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatAbout : IMethod<bool>
	{


        public static int ConstructorId { get; } = -554301545;

		public Type Type { get; init; } = typeof(EditChatAbout);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }
		public string About { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(About);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			About = reader.Read<string>();

		}
	}
}
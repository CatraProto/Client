using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class HidePeerSettingsBar : IMethod<bool>
	{


        public static int ConstructorId { get; } = 1336717624;

		public Type Type { get; init; } = typeof(HidePeerSettingsBar);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();

		}
	}
}
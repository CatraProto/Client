using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateNotifySettings : IMethod
	{
		public static int ConstructorId { get; } = -2067899501;
		public InputNotifyPeerBase Peer { get; set; }
		public InputPeerNotifySettingsBase Settings { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Peer);
			writer.Write(Settings);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputNotifyPeerBase>();
			Settings = reader.Read<InputPeerNotifySettingsBase>();
		}
	}
}
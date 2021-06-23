using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNotifySettings : UpdateBase
	{
		public static int ConstructorId { get; } = -1094555409;
		public NotifyPeerBase Peer { get; set; }
		public PeerNotifySettingsBase NotifySettings { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Peer);
			writer.Write(NotifySettings);
		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<NotifyPeerBase>();
			NotifySettings = reader.Read<PeerNotifySettingsBase>();
		}
	}
}
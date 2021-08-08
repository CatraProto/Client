using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDialogUnreadMark : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Unread = 1 << 0
		}

        public static int StaticConstructorId { get => -513517117; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("unread")]
		public bool Unread { get; set; }

[JsonPropertyName("peer")]
		public DialogPeerBase Peer { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Unread = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<DialogPeerBase>();

		}
	}
}
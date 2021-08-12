using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDialogPinned : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pinned = 1 << 0,
			FolderId = 1 << 1
		}

        public static int StaticConstructorId { get => 1852826908; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("pinned")]
		public bool Pinned { get; set; }

[JsonPropertyName("folder_id")]
		public int? FolderId { get; set; }

[JsonPropertyName("peer")]
		public DialogPeerBase Peer { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(Peer);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pinned = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				FolderId = reader.Read<int>();
			}

			Peer = reader.Read<DialogPeerBase>();
		}

		public override string ToString()
		{
			return "updateDialogPinned";
		}
	}
}
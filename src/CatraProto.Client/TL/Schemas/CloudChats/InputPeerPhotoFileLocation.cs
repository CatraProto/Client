using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerPhotoFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Big = 1 << 0
		}

        public static int StaticConstructorId { get => 668375447; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("big")]
		public bool Big { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[JsonPropertyName("volume_id")]
		public long VolumeId { get; set; }

[JsonPropertyName("local_id")]
		public int LocalId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(VolumeId);
			writer.Write(LocalId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Big = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();

		}
	}
}
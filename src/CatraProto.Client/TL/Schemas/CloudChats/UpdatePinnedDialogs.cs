using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePinnedDialogs : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 1,
			Order = 1 << 0
		}

        public static int StaticConstructorId { get => -99664734; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("folder_id")]
		public int? FolderId { get; set; }

[JsonPropertyName("order")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase> Order { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Order == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

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

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Order);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				FolderId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Order = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
			}


		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetNotifyExceptions : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			CompareSound = 1 << 1,
			Peer = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1398240377; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("compare_sound")]
		public bool CompareSound { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase Peer { get; set; }


		public void UpdateFlags() 
		{
			Flags = CompareSound ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Peer);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CompareSound = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase>();
			}


		}
	}
}
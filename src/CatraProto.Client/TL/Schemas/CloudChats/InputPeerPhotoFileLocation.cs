using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerPhotoFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Big = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 925204121; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("big")]
		public bool Big { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public long PhotoId { get; set; }


        #nullable enable
 public InputPeerPhotoFileLocation (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,long photoId)
{
 Peer = peer;
PhotoId = photoId;
 
}
#nullable disable
        internal InputPeerPhotoFileLocation() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(PhotoId);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Big = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			PhotoId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "inputPeerPhotoFileLocation";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
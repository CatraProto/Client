using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GroupCallParticipant : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Muted = 1 << 0,
			Left = 1 << 1,
			CanSelfUnmute = 1 << 2,
			JustJoined = 1 << 4,
			Versioned = 1 << 5,
			Min = 1 << 8,
			MutedByYou = 1 << 9,
			VolumeByAdmin = 1 << 10,
			Self = 1 << 12,
			VideoJoined = 1 << 15,
			ActiveDate = 1 << 3,
			Volume = 1 << 7,
			About = 1 << 11,
			RaiseHandRating = 1 << 13,
			Video = 1 << 6,
			Presentation = 1 << 14
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -341428482; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("muted")]
		public sealed override bool Muted { get; set; }

[Newtonsoft.Json.JsonProperty("left")]
		public sealed override bool Left { get; set; }

[Newtonsoft.Json.JsonProperty("can_self_unmute")]
		public sealed override bool CanSelfUnmute { get; set; }

[Newtonsoft.Json.JsonProperty("just_joined")]
		public sealed override bool JustJoined { get; set; }

[Newtonsoft.Json.JsonProperty("versioned")]
		public sealed override bool Versioned { get; set; }

[Newtonsoft.Json.JsonProperty("min")]
		public sealed override bool Min { get; set; }

[Newtonsoft.Json.JsonProperty("muted_by_you")]
		public sealed override bool MutedByYou { get; set; }

[Newtonsoft.Json.JsonProperty("volume_by_admin")]
		public sealed override bool VolumeByAdmin { get; set; }

[Newtonsoft.Json.JsonProperty("self")]
		public sealed override bool Self { get; set; }

[Newtonsoft.Json.JsonProperty("video_joined")]
		public sealed override bool VideoJoined { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("active_date")]
		public sealed override int? ActiveDate { get; set; }

[Newtonsoft.Json.JsonProperty("source")]
		public sealed override int Source { get; set; }

[Newtonsoft.Json.JsonProperty("volume")]
		public sealed override int? Volume { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public sealed override string About { get; set; }

[Newtonsoft.Json.JsonProperty("raise_hand_rating")]
		public sealed override long? RaiseHandRating { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Video { get; set; }

[Newtonsoft.Json.JsonProperty("presentation")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Presentation { get; set; }


        #nullable enable
 public GroupCallParticipant (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int date,int source)
{
 Peer = peer;
Date = date;
Source = source;
 
}
#nullable disable
        internal GroupCallParticipant() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Muted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Left ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = CanSelfUnmute ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = JustJoined ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Versioned ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Min ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = MutedByYou ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
			Flags = VolumeByAdmin ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Self ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = VideoJoined ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
			Flags = ActiveDate == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Volume == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = RaiseHandRating == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
			Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Presentation == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Date);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ActiveDate.Value);
			}

			writer.Write(Source);
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Volume.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(About);
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				writer.Write(RaiseHandRating.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(Video);
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(Presentation);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Muted = FlagsHelper.IsFlagSet(Flags, 0);
			Left = FlagsHelper.IsFlagSet(Flags, 1);
			CanSelfUnmute = FlagsHelper.IsFlagSet(Flags, 2);
			JustJoined = FlagsHelper.IsFlagSet(Flags, 4);
			Versioned = FlagsHelper.IsFlagSet(Flags, 5);
			Min = FlagsHelper.IsFlagSet(Flags, 8);
			MutedByYou = FlagsHelper.IsFlagSet(Flags, 9);
			VolumeByAdmin = FlagsHelper.IsFlagSet(Flags, 10);
			Self = FlagsHelper.IsFlagSet(Flags, 12);
			VideoJoined = FlagsHelper.IsFlagSet(Flags, 15);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Date = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ActiveDate = reader.Read<int>();
			}

			Source = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				Volume = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				About = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				RaiseHandRating = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				Video = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				Presentation = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase>();
			}


		}
		
		public override string ToString()
		{
		    return "groupCallParticipant";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
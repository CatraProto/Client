using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GroupCall : CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			JoinMuted = 1 << 1,
			CanChangeJoinMuted = 1 << 2,
			JoinDateAsc = 1 << 6,
			ScheduleStartSubscribed = 1 << 8,
			CanStartVideo = 1 << 9,
			RecordVideoActive = 1 << 11,
			RtmpStream = 1 << 12,
			ListenersHidden = 1 << 13,
			Title = 1 << 3,
			StreamDcId = 1 << 4,
			RecordStartDate = 1 << 5,
			ScheduleDate = 1 << 7,
			UnmutedVideoCount = 1 << 10
		}

        public static int StaticConstructorId { get => -711498484; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("join_muted")]
		public bool JoinMuted { get; set; }

[Newtonsoft.Json.JsonProperty("can_change_join_muted")]
		public bool CanChangeJoinMuted { get; set; }

[Newtonsoft.Json.JsonProperty("join_date_asc")]
		public bool JoinDateAsc { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_start_subscribed")]
		public bool ScheduleStartSubscribed { get; set; }

[Newtonsoft.Json.JsonProperty("can_start_video")]
		public bool CanStartVideo { get; set; }

[Newtonsoft.Json.JsonProperty("record_video_active")]
		public bool RecordVideoActive { get; set; }

[Newtonsoft.Json.JsonProperty("rtmp_stream")]
		public bool RtmpStream { get; set; }

[Newtonsoft.Json.JsonProperty("listeners_hidden")]
		public bool ListenersHidden { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("participants_count")]
		public int ParticipantsCount { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("stream_dc_id")]
		public int? StreamDcId { get; set; }

[Newtonsoft.Json.JsonProperty("record_start_date")]
		public int? RecordStartDate { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }

[Newtonsoft.Json.JsonProperty("unmuted_video_count")]
		public int? UnmutedVideoCount { get; set; }

[Newtonsoft.Json.JsonProperty("unmuted_video_limit")]
		public int UnmutedVideoLimit { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }


        #nullable enable
 public GroupCall (long id,long accessHash,int participantsCount,int unmutedVideoLimit,int version)
{
 Id = id;
AccessHash = accessHash;
ParticipantsCount = participantsCount;
UnmutedVideoLimit = unmutedVideoLimit;
Version = version;
 
}
#nullable disable
        internal GroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = JoinMuted ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = CanChangeJoinMuted ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = JoinDateAsc ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ScheduleStartSubscribed ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = CanStartVideo ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
			Flags = RecordVideoActive ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = RtmpStream ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = ListenersHidden ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = StreamDcId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = RecordStartDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
			Flags = UnmutedVideoCount == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(ParticipantsCount);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(StreamDcId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(RecordStartDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(ScheduleDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(UnmutedVideoCount.Value);
			}

			writer.Write(UnmutedVideoLimit);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			JoinMuted = FlagsHelper.IsFlagSet(Flags, 1);
			CanChangeJoinMuted = FlagsHelper.IsFlagSet(Flags, 2);
			JoinDateAsc = FlagsHelper.IsFlagSet(Flags, 6);
			ScheduleStartSubscribed = FlagsHelper.IsFlagSet(Flags, 8);
			CanStartVideo = FlagsHelper.IsFlagSet(Flags, 9);
			RecordVideoActive = FlagsHelper.IsFlagSet(Flags, 11);
			RtmpStream = FlagsHelper.IsFlagSet(Flags, 12);
			ListenersHidden = FlagsHelper.IsFlagSet(Flags, 13);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			ParticipantsCount = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Title = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				StreamDcId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				RecordStartDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 7))
			{
				ScheduleDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				UnmutedVideoCount = reader.Read<int>();
			}

			UnmutedVideoLimit = reader.Read<int>();
			Version = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "groupCall";
		}
	}
}
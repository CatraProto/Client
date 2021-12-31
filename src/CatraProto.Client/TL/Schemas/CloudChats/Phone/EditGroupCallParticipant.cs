using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class EditGroupCallParticipant : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Muted = 1 << 0,
			Volume = 1 << 1,
			RaiseHand = 1 << 2,
			VideoStopped = 1 << 3,
			VideoPaused = 1 << 4,
			PresentationPaused = 1 << 5
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1524155713; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Participant { get; set; }

[Newtonsoft.Json.JsonProperty("muted")]
		public bool? Muted { get; set; }

[Newtonsoft.Json.JsonProperty("volume")]
		public int? Volume { get; set; }

[Newtonsoft.Json.JsonProperty("raise_hand")]
		public bool? RaiseHand { get; set; }

[Newtonsoft.Json.JsonProperty("video_stopped")]
		public bool? VideoStopped { get; set; }

[Newtonsoft.Json.JsonProperty("video_paused")]
		public bool? VideoPaused { get; set; }

[Newtonsoft.Json.JsonProperty("presentation_paused")]
		public bool? PresentationPaused { get; set; }


		public void UpdateFlags() 
		{
			Flags = Muted == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Volume == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = RaiseHand == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = VideoStopped == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = VideoPaused == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PresentationPaused == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Call);
			writer.Write(Participant);
			writer.Write(Muted.Value);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Volume.Value);
			}

			writer.Write(RaiseHand.Value);
			writer.Write(VideoStopped.Value);
			writer.Write(VideoPaused.Value);
			writer.Write(PresentationPaused.Value);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
			Muted = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Volume = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
			RaiseHand = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
			VideoStopped = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
			VideoPaused = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
			PresentationPaused = reader.Read<bool>();
			}


		}
		
		public override string ToString()
		{
		    return "phone.editGroupCallParticipant";
		}
	}
}
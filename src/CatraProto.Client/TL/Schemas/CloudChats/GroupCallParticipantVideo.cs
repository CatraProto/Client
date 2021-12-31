using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GroupCallParticipantVideo : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Paused = 1 << 0,
			AudioSource = 1 << 1
		}

        public static int StaticConstructorId { get => 1735736008; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("paused")]
		public override bool Paused { get; set; }

[Newtonsoft.Json.JsonProperty("endpoint")]
		public override string Endpoint { get; set; }

[Newtonsoft.Json.JsonProperty("source_groups")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase> SourceGroups { get; set; }

[Newtonsoft.Json.JsonProperty("audio_source")]
		public override int? AudioSource { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Paused ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = AudioSource == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Endpoint);
			writer.Write(SourceGroups);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(AudioSource.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Paused = FlagsHelper.IsFlagSet(Flags, 0);
			Endpoint = reader.Read<string>();
			SourceGroups = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				AudioSource = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "groupCallParticipantVideo";
		}
	}
}
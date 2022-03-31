using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ForwardMessages : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 5,
			Background = 1 << 6,
			WithMyScore = 1 << 8,
			DropAuthor = 1 << 11,
			DropMediaCaptions = 1 << 12,
			Noforwards = 1 << 14,
			ScheduleDate = 1 << 10,
			SendAs = 1 << 13
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -869258997; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

[Newtonsoft.Json.JsonProperty("background")]
		public bool Background { get; set; }

[Newtonsoft.Json.JsonProperty("with_my_score")]
		public bool WithMyScore { get; set; }

[Newtonsoft.Json.JsonProperty("drop_author")]
		public bool DropAuthor { get; set; }

[Newtonsoft.Json.JsonProperty("drop_media_captions")]
		public bool DropMediaCaptions { get; set; }

[Newtonsoft.Json.JsonProperty("noforwards")]
		public bool Noforwards { get; set; }

[Newtonsoft.Json.JsonProperty("from_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase FromPeer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public IList<int> Id { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public IList<long> RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("to_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase ToPeer { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }

[Newtonsoft.Json.JsonProperty("send_as")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }

        
        #nullable enable
 public ForwardMessages (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromPeer,IList<int> id,IList<long> randomId,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase toPeer)
{
 FromPeer = fromPeer;
Id = id;
RandomId = randomId;
ToPeer = toPeer;
 
}
#nullable disable
                
        internal ForwardMessages() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = WithMyScore ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = DropAuthor ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
			Flags = DropMediaCaptions ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
			Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
			Flags = SendAs == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FromPeer);
			writer.Write(Id);
			writer.Write(RandomId);
			writer.Write(ToPeer);
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				writer.Write(ScheduleDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				writer.Write(SendAs);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 5);
			Background = FlagsHelper.IsFlagSet(Flags, 6);
			WithMyScore = FlagsHelper.IsFlagSet(Flags, 8);
			DropAuthor = FlagsHelper.IsFlagSet(Flags, 11);
			DropMediaCaptions = FlagsHelper.IsFlagSet(Flags, 12);
			Noforwards = FlagsHelper.IsFlagSet(Flags, 14);
			FromPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.ReadVector<int>();
			RandomId = reader.ReadVector<long>();
			ToPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 10))
			{
				ScheduleDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 13))
			{
				SendAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			}


		}

		public override string ToString()
		{
		    return "messages.forwardMessages";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
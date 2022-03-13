using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class CreateGroupCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			RtmpStream = 1 << 2,
			Title = 1 << 0,
			ScheduleDate = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1221445336; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("rtmp_stream")]
		public bool RtmpStream { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public int RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("schedule_date")]
		public int? ScheduleDate { get; set; }

        
        #nullable enable
 public CreateGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int randomId)
{
 Peer = peer;
RandomId = randomId;
 
}
#nullable disable
                
        internal CreateGroupCall() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = RtmpStream ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(RandomId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ScheduleDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RtmpStream = FlagsHelper.IsFlagSet(Flags, 2);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			RandomId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Title = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ScheduleDate = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "phone.createGroupCall";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteHistory : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			JustClear = 1 << 0,
			Revoke = 1 << 1,
			MinDate = 1 << 2,
			MaxDate = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1332768214; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("just_clear")]
		public bool JustClear { get; set; }

[Newtonsoft.Json.JsonProperty("revoke")]
		public bool Revoke { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public int MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("min_date")]
		public int? MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("max_date")]
		public int? MaxDate { get; set; }

        
        #nullable enable
 public DeleteHistory (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int maxId)
{
 Peer = peer;
MaxId = maxId;
 
}
#nullable disable
                
        internal DeleteHistory() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = JustClear ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Revoke ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = MinDate == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = MaxDate == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(MaxId);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(MinDate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(MaxDate.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			JustClear = FlagsHelper.IsFlagSet(Flags, 0);
			Revoke = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			MaxId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				MinDate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				MaxDate = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.deleteHistory";
		}
	}
}
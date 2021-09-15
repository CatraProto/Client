using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessageStats : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1226791947; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("dark")]
		public bool Dark { get; set; }

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }


		public void UpdateFlags() 
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			MsgId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "stats.getMessageStats";
		}
	}
}
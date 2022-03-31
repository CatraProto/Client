using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGroupCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Duration = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2047704898; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("duration")]
		public int? Duration { get; set; }


        #nullable enable
 public MessageActionGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
{
 Call = call;
 
}
#nullable disable
        internal MessageActionGroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Duration == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Call);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Duration.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Duration = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messageActionGroupCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
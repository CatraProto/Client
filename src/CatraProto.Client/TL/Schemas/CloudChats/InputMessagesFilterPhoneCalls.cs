using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessagesFilterPhoneCalls : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Missed = 1 << 0
		}

        public static int StaticConstructorId { get => -2134272152; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("missed")]
		public bool Missed { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Missed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Missed = FlagsHelper.IsFlagSet(Flags, 0);

		}
				
		public override string ToString()
		{
		    return "inputMessagesFilterPhoneCalls";
		}
	}
}
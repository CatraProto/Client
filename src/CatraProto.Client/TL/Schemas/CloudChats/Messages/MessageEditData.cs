using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageEditData : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Caption = 1 << 0
		}

        public static int StaticConstructorId { get => 649453030; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public override bool Caption { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Caption ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

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
			Caption = FlagsHelper.IsFlagSet(Flags, 0);

		}
				
		public override string ToString()
		{
		    return "messages.messageEditData";
		}
	}
}
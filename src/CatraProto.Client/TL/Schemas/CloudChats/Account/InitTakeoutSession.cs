using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InitTakeoutSession : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Contacts = 1 << 0,
			MessageUsers = 1 << 1,
			MessageChats = 1 << 2,
			MessageMegagroups = 1 << 3,
			MessageChannels = 1 << 4,
			Files = 1 << 5,
			FileMaxSize = 1 << 5
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -262453244; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("contacts")]
		public bool Contacts { get; set; }

[Newtonsoft.Json.JsonProperty("message_users")]
		public bool MessageUsers { get; set; }

[Newtonsoft.Json.JsonProperty("message_chats")]
		public bool MessageChats { get; set; }

[Newtonsoft.Json.JsonProperty("message_megagroups")]
		public bool MessageMegagroups { get; set; }

[Newtonsoft.Json.JsonProperty("message_channels")]
		public bool MessageChannels { get; set; }

[Newtonsoft.Json.JsonProperty("files")]
		public bool Files { get; set; }

[Newtonsoft.Json.JsonProperty("file_max_size")]
		public int? FileMaxSize { get; set; }

        
        
                
        public InitTakeoutSession() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Contacts ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = MessageUsers ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = MessageChats ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = MessageMegagroups ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = MessageChannels ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Files ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = FileMaxSize == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(FileMaxSize.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Contacts = FlagsHelper.IsFlagSet(Flags, 0);
			MessageUsers = FlagsHelper.IsFlagSet(Flags, 1);
			MessageChats = FlagsHelper.IsFlagSet(Flags, 2);
			MessageMegagroups = FlagsHelper.IsFlagSet(Flags, 3);
			MessageChannels = FlagsHelper.IsFlagSet(Flags, 4);
			Files = FlagsHelper.IsFlagSet(Flags, 5);
			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				FileMaxSize = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "account.initTakeoutSession";
		}
	}
}
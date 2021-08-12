using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class DeepLinkInfo : DeepLinkInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			UpdateApp = 1 << 0,
			Entities = 1 << 1
		}

        public static int StaticConstructorId { get => 1783556146; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("update_app")]
		public bool UpdateApp { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("entities")]
		public IList<MessageEntityBase> Entities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = UpdateApp ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Entities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UpdateApp = FlagsHelper.IsFlagSet(Flags, 0);
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}

		public override string ToString()
		{
			return "help.deepLinkInfo";
		}
	}
}
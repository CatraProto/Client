using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UrlAuthResultRequest : UrlAuthResultBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequestWriteAccess = 1 << 0
		}

        public static int StaticConstructorId { get => -1831650802; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("request_write_access")]
		public bool RequestWriteAccess { get; set; }

[JsonPropertyName("bot")]
		public UserBase Bot { get; set; }

[JsonPropertyName("domain")]
		public string Domain { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Bot);
			writer.Write(Domain);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
			Bot = reader.Read<UserBase>();
			Domain = reader.Read<string>();

		}
	}
}
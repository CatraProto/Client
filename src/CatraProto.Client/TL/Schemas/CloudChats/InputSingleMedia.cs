using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputSingleMedia : InputSingleMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Entities = 1 << 0
		}

        public static int StaticConstructorId { get => 482797855; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("media")]
		public override InputMediaBase Media { get; set; }

[JsonPropertyName("random_id")]
		public override long RandomId { get; set; }

[JsonPropertyName("message")]
		public override string Message { get; set; }

[JsonPropertyName("entities")]
		public override IList<MessageEntityBase> Entities { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Media);
			writer.Write(RandomId);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Entities);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Media = reader.Read<InputMediaBase>();
			RandomId = reader.Read<long>();
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}


		}
	}
}
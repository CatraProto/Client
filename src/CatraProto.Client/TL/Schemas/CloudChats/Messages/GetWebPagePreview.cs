using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPagePreview : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Entities = 1 << 3
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1956073268; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


		public void UpdateFlags() 
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}


		}
	}
}
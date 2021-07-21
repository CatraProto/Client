using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteMessages : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Revoke = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -443640366; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("revoke")]
		public bool Revoke { get; set; }

[JsonPropertyName("id")]
		public IList<int> Id { get; set; }


		public void UpdateFlags() 
		{
			Flags = Revoke ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Revoke = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.ReadVector<int>();

		}
	}
}
using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class FinishTakeoutSession : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Success = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 489050862; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("success")]
		public bool Success { get; set; }


		public void UpdateFlags() 
		{
			Flags = Success ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Success = FlagsHelper.IsFlagSet(Flags, 0);
		}

		public override string ToString()
		{
			return "account.finishTakeoutSession";
		}
	}
}
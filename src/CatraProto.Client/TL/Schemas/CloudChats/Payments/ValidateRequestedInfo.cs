using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class ValidateRequestedInfo : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Save = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1997180532; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ValidatedRequestedInfoBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("save")]
		public bool Save { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("info")]
		public PaymentRequestedInfoBase Info { get; set; }


		public void UpdateFlags() 
		{
			Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(MsgId);
			writer.Write(Info);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Save = FlagsHelper.IsFlagSet(Flags, 0);
			MsgId = reader.Read<int>();
			Info = reader.Read<PaymentRequestedInfoBase>();

		}
	}
}
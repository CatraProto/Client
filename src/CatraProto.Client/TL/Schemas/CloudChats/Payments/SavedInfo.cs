using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class SavedInfo : SavedInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasSavedCredentials = 1 << 1,
			SavedInfo_ = 1 << 0
		}

        public static int StaticConstructorId { get => -74456004; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("has_saved_credentials")]
		public override bool HasSavedCredentials { get; set; }

[JsonPropertyName("SavedInfo_")]
		public override PaymentRequestedInfoBase SavedInfo_ { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = HasSavedCredentials ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = SavedInfo_ == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(SavedInfo_);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasSavedCredentials = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				SavedInfo_ = reader.Read<PaymentRequestedInfoBase>();
			}


		}
	}
}
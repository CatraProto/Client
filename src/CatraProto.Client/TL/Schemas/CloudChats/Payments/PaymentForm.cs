using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentForm : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanSaveCredentials = 1 << 2,
			PasswordMissing = 1 << 3,
			NativeProvider = 1 << 4,
			NativeParams = 1 << 4,
			SavedInfo = 1 << 0,
			SavedCredentials = 1 << 1
		}

        public static int StaticConstructorId { get => 1062645411; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("can_save_credentials")]
		public override bool CanSaveCredentials { get; set; }

[JsonPropertyName("password_missing")]
		public override bool PasswordMissing { get; set; }

[JsonPropertyName("bot_id")]
		public override int BotId { get; set; }

[JsonPropertyName("invoice")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[JsonPropertyName("provider_id")]
		public override int ProviderId { get; set; }

[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("native_provider")]
		public override string NativeProvider { get; set; }

[JsonPropertyName("native_params")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

[JsonPropertyName("saved_info")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

[JsonPropertyName("saved_credentials")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = CanSaveCredentials ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = PasswordMissing ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = NativeProvider == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = NativeParams == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = SavedInfo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = SavedCredentials == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(BotId);
			writer.Write(Invoice);
			writer.Write(ProviderId);
			writer.Write(Url);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(NativeProvider);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(NativeParams);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(SavedInfo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(SavedCredentials);
			}

			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanSaveCredentials = FlagsHelper.IsFlagSet(Flags, 2);
			PasswordMissing = FlagsHelper.IsFlagSet(Flags, 3);
			BotId = reader.Read<int>();
			Invoice = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
			ProviderId = reader.Read<int>();
			Url = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				NativeProvider = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				NativeParams = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				SavedInfo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				SavedCredentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase>();
			}

			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}
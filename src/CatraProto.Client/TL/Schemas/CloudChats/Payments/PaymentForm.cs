using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 378828315; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("can_save_credentials")]
		public sealed override bool CanSaveCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("password_missing")]
		public sealed override bool PasswordMissing { get; set; }

[Newtonsoft.Json.JsonProperty("form_id")]
		public sealed override long FormId { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public sealed override long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("invoice")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[Newtonsoft.Json.JsonProperty("provider_id")]
		public sealed override long ProviderId { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("native_provider")]
		public sealed override string NativeProvider { get; set; }

[Newtonsoft.Json.JsonProperty("native_params")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

[Newtonsoft.Json.JsonProperty("saved_info")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

[Newtonsoft.Json.JsonProperty("saved_credentials")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public PaymentForm (long formId,long botId,CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice,long providerId,string url,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 FormId = formId;
BotId = botId;
Invoice = invoice;
ProviderId = providerId;
Url = url;
Users = users;
 
}
#nullable disable
        internal PaymentForm() 
        {
        }
		
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
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FormId);
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
			FormId = reader.Read<long>();
			BotId = reader.Read<long>();
			Invoice = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
			ProviderId = reader.Read<long>();
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
		
		public override string ToString()
		{
		    return "payments.paymentForm";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
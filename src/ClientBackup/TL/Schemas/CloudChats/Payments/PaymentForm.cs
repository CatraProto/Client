using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

[MaybeNull]
[Newtonsoft.Json.JsonProperty("native_provider")]
		public sealed override string NativeProvider { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("native_params")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("saved_info")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("saved_credentials")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public PaymentForm (long formId,long botId,CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice,long providerId,string url,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(FormId);
writer.WriteInt64(BotId);
var checkinvoice = 			writer.WriteObject(Invoice);
if(checkinvoice.IsError){
 return checkinvoice; 
}
writer.WriteInt64(ProviderId);

			writer.WriteString(Url);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{

				writer.WriteString(NativeProvider);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
var checknativeParams = 				writer.WriteObject(NativeParams);
if(checknativeParams.IsError){
 return checknativeParams; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checksavedInfo = 				writer.WriteObject(SavedInfo);
if(checksavedInfo.IsError){
 return checksavedInfo; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checksavedCredentials = 				writer.WriteObject(SavedCredentials);
if(checksavedCredentials.IsError){
 return checksavedCredentials; 
}
			}

var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			CanSaveCredentials = FlagsHelper.IsFlagSet(Flags, 2);
			PasswordMissing = FlagsHelper.IsFlagSet(Flags, 3);
			var tryformId = reader.ReadInt64();
if(tryformId.IsError){
return ReadResult<IObject>.Move(tryformId);
}
FormId = tryformId.Value;
			var trybotId = reader.ReadInt64();
if(trybotId.IsError){
return ReadResult<IObject>.Move(trybotId);
}
BotId = trybotId.Value;
			var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
if(tryinvoice.IsError){
return ReadResult<IObject>.Move(tryinvoice);
}
Invoice = tryinvoice.Value;
			var tryproviderId = reader.ReadInt64();
if(tryproviderId.IsError){
return ReadResult<IObject>.Move(tryproviderId);
}
ProviderId = tryproviderId.Value;
			var tryurl = reader.ReadString();
if(tryurl.IsError){
return ReadResult<IObject>.Move(tryurl);
}
Url = tryurl.Value;
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trynativeProvider = reader.ReadString();
if(trynativeProvider.IsError){
return ReadResult<IObject>.Move(trynativeProvider);
}
NativeProvider = trynativeProvider.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trynativeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
if(trynativeParams.IsError){
return ReadResult<IObject>.Move(trynativeParams);
}
NativeParams = trynativeParams.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trysavedInfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
if(trysavedInfo.IsError){
return ReadResult<IObject>.Move(trysavedInfo);
}
SavedInfo = trysavedInfo.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trysavedCredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase>();
if(trysavedCredentials.IsError){
return ReadResult<IObject>.Move(trysavedCredentials);
}
SavedCredentials = trysavedCredentials.Value;
			}

			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

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
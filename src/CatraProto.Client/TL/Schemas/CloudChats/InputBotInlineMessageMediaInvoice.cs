using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineMessageMediaInvoice : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Photo = 1 << 0,
			ReplyMarkup = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -672693723; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public string Description { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("invoice")]
		public CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[Newtonsoft.Json.JsonProperty("payload")]
		public byte[] Payload { get; set; }

[Newtonsoft.Json.JsonProperty("provider")]
		public string Provider { get; set; }

[Newtonsoft.Json.JsonProperty("provider_data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase ProviderData { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("reply_markup")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


        #nullable enable
 public InputBotInlineMessageMediaInvoice (string title,string description,CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice,byte[] payload,string provider,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase providerData)
{
 Title = title;
Description = description;
Invoice = invoice;
Payload = payload;
Provider = provider;
ProviderData = providerData;
 
}
#nullable disable
        internal InputBotInlineMessageMediaInvoice() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteString(Title);

			writer.WriteString(Description);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkphoto = 				writer.WriteObject(Photo);
if(checkphoto.IsError){
 return checkphoto; 
}
			}

var checkinvoice = 			writer.WriteObject(Invoice);
if(checkinvoice.IsError){
 return checkinvoice; 
}

			writer.WriteBytes(Payload);

			writer.WriteString(Provider);
var checkproviderData = 			writer.WriteObject(ProviderData);
if(checkproviderData.IsError){
 return checkproviderData; 
}
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkreplyMarkup = 				writer.WriteObject(ReplyMarkup);
if(checkreplyMarkup.IsError){
 return checkreplyMarkup; 
}
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
			var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
			var trydescription = reader.ReadString();
if(trydescription.IsError){
return ReadResult<IObject>.Move(trydescription);
}
Description = trydescription.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
if(tryphoto.IsError){
return ReadResult<IObject>.Move(tryphoto);
}
Photo = tryphoto.Value;
			}

			var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
if(tryinvoice.IsError){
return ReadResult<IObject>.Move(tryinvoice);
}
Invoice = tryinvoice.Value;
			var trypayload = reader.ReadBytes();
if(trypayload.IsError){
return ReadResult<IObject>.Move(trypayload);
}
Payload = trypayload.Value;
			var tryprovider = reader.ReadString();
if(tryprovider.IsError){
return ReadResult<IObject>.Move(tryprovider);
}
Provider = tryprovider.Value;
			var tryproviderData = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
if(tryproviderData.IsError){
return ReadResult<IObject>.Move(tryproviderData);
}
ProviderData = tryproviderData.Value;
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
if(tryreplyMarkup.IsError){
return ReadResult<IObject>.Move(tryreplyMarkup);
}
ReplyMarkup = tryreplyMarkup.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputBotInlineMessageMediaInvoice";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
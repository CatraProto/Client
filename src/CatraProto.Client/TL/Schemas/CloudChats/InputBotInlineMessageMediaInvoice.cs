using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        public static int StaticConstructorId { get => -672693723; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public string Description { get; set; }

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

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(Description);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Photo);
			}

			writer.Write(Invoice);
			writer.Write(Payload);
			writer.Write(Provider);
			writer.Write(ProviderData);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
			}

			Invoice = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
			Payload = reader.Read<byte[]>();
			Provider = reader.Read<string>();
			ProviderData = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}


		}
				
		public override string ToString()
		{
		    return "inputBotInlineMessageMediaInvoice";
		}
	}
}
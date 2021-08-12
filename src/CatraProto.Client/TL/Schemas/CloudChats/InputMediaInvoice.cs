using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaInvoice : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Photo = 1 << 0
		}

        public static int StaticConstructorId { get => -186607933; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("description")]
		public string Description { get; set; }

[JsonPropertyName("photo")]
		public InputWebDocumentBase Photo { get; set; }

[JsonPropertyName("invoice")]
		public InvoiceBase Invoice { get; set; }

[JsonPropertyName("payload")]
		public byte[] Payload { get; set; }

[JsonPropertyName("provider")]
		public string Provider { get; set; }

[JsonPropertyName("provider_data")]
		public DataJSONBase ProviderData { get; set; }

[JsonPropertyName("start_param")]
		public string StartParam { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

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
			writer.Write(StartParam);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Photo = reader.Read<InputWebDocumentBase>();
			}

			Invoice = reader.Read<InvoiceBase>();
			Payload = reader.Read<byte[]>();
			Provider = reader.Read<string>();
			ProviderData = reader.Read<DataJSONBase>();
			StartParam = reader.Read<string>();
		}

		public override string ToString()
		{
			return "inputMediaInvoice";
		}
	}
}
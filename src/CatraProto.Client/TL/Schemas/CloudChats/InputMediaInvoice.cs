using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaInvoice : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Photo = 1 << 0,
            StartParam = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => -646342540;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

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

        [Newtonsoft.Json.JsonProperty("start_param")]
        public string StartParam { get; set; }


    #nullable enable
        public InputMediaInvoice(string title, string description, CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice, byte[] payload, string provider, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase providerData)
        {
            Title = title;
            Description = description;
            Invoice = invoice;
            Payload = payload;
            Provider = provider;
            ProviderData = providerData;
        }
    #nullable disable
        internal InputMediaInvoice()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = StartParam == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Title);
            writer.Write(Description);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Photo);
            }

            writer.Write(Invoice);
            writer.Write(Payload);
            writer.Write(Provider);
            writer.Write(ProviderData);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(StartParam);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Title = reader.Read<string>();
            Description = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase>();
            }

            Invoice = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
            Payload = reader.Read<byte[]>();
            Provider = reader.Read<string>();
            ProviderData = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                StartParam = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "inputMediaInvoice";
        }
    }
}
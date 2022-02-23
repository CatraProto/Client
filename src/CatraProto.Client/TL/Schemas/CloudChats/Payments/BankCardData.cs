using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class BankCardData : CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase
    {
        public static int StaticConstructorId
        {
            get => 1042605427;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("open_urls")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }


    #nullable enable
        public BankCardData(string title, IList<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> openUrls)
        {
            Title = title;
            OpenUrls = openUrls;
        }
    #nullable disable
        internal BankCardData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Title);
            writer.Write(OpenUrls);
        }

        public override void Deserialize(Reader reader)
        {
            Title = reader.Read<string>();
            OpenUrls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>();
        }

        public override string ToString()
        {
            return "payments.bankCardData";
        }
    }
}
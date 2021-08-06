using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class BankCardData : CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase
	{


        public static int StaticConstructorId { get => 1042605427; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("title")]
		public override string Title { get; set; }

[JsonPropertyName("open_urls")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(OpenUrls);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
			OpenUrls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>();

		}
	}
}
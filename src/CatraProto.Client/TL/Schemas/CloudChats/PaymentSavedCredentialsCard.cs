using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentSavedCredentialsCard : CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase
	{


        public static int StaticConstructorId { get => -842892769; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public override string Title { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Title = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "paymentSavedCredentialsCard";
		}
	}
}
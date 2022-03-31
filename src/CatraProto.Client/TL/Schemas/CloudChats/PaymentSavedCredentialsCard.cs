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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -842892769; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }


        #nullable enable
 public PaymentSavedCredentialsCard (string id,string title)
{
 Id = id;
Title = title;
 
}
#nullable disable
        internal PaymentSavedCredentialsCard() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
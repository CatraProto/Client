using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetPaymentForm : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1712285883; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "payments.getPaymentForm";
		}
	}
}
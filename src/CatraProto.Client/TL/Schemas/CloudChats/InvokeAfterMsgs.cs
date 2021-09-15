using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeAfterMsgs : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1036301552; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("msg_ids")]
		public IList<long> MsgIds { get; set; }

[Newtonsoft.Json.JsonProperty("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgIds);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();
			Query = reader.Read<IObject>();

		}
		
		public override string ToString()
		{
		    return "invokeAfterMsgs";
		}
	}
}
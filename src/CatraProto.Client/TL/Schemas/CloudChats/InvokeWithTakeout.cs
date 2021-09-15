using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithTakeout : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1398145746; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("takeout_id")]
		public long TakeoutId { get; set; }

[Newtonsoft.Json.JsonProperty("query")]
		public IObject Query { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TakeoutId);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			TakeoutId = reader.Read<long>();
			Query = reader.Read<IObject>();

		}
		
		public override string ToString()
		{
		    return "invokeWithTakeout";
		}
	}
}
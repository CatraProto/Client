using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReceivedQueue : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1436924774; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(long);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("max_qts")]
		public int MaxQts { get; set; }

        
        #nullable enable
 public ReceivedQueue (int maxQts)
{
 MaxQts = maxQts;
 
}
#nullable disable
                
        internal ReceivedQueue() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(MaxQts);

		}

		public void Deserialize(Reader reader)
		{
			MaxQts = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.receivedQueue";
		}
	}
}
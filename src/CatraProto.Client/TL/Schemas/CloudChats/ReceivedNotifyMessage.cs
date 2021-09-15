using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReceivedNotifyMessage : CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase
	{


        public static int StaticConstructorId { get => -1551583367; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("flags")]
		public override int Flags { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Flags = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "receivedNotifyMessage";
		}
	}
}
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
		public sealed override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("flags")]
		public sealed override int Flags { get; set; }


        #nullable enable
 public ReceivedNotifyMessage (int id,int flags)
{
 Id = id;
Flags = flags;
 
}
#nullable disable
        internal ReceivedNotifyMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
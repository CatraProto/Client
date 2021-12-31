using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetDiscussionGroup : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1079520178; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("broadcast")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Broadcast { get; set; }

[Newtonsoft.Json.JsonProperty("group")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Group { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Broadcast);
			writer.Write(Group);

		}

		public void Deserialize(Reader reader)
		{
			Broadcast = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Group = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();

		}
		
		public override string ToString()
		{
		    return "channels.setDiscussionGroup";
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class SetDiscussionGroup : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1079520178; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("broadcast")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Broadcast { get; set; }

[JsonPropertyName("group")]
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
	}
}
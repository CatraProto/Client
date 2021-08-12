using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("broadcast")]
		public InputChannelBase Broadcast { get; set; }

[JsonPropertyName("group")]
		public InputChannelBase Group { get; set; }


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
			Broadcast = reader.Read<InputChannelBase>();
			Group = reader.Read<InputChannelBase>();
		}

		public override string ToString()
		{
			return "channels.setDiscussionGroup";
		}
	}
}
using System;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetLeftChannels : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2092831552; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ChatsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("offset")]
		public int Offset { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
		}

		public override string ToString()
		{
			return "channels.getLeftChannels";
		}
	}
}
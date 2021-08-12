using System;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetInactiveChannels : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 300429806; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(InactiveChatsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{
		}

		public override string ToString()
		{
			return "channels.getInactiveChannels";
		}
	}
}
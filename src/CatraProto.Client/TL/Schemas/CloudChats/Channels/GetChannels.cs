using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetChannels : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 176122811; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase> Id { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();

		}
	}
}
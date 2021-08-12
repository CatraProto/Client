using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class InviteToChannel : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 429865580; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("channel")]
		public InputChannelBase Channel { get; set; }

[JsonPropertyName("users")]
		public IList<InputUserBase> Users { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Users);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			Users = reader.ReadVector<InputUserBase>();
		}

		public override string ToString()
		{
			return "channels.inviteToChannel";
		}
	}
}
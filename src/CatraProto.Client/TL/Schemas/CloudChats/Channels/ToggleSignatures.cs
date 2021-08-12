using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ToggleSignatures : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 527021574; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("channel")]
		public InputChannelBase Channel { get; set; }

[JsonPropertyName("enabled")]
		public bool Enabled { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Enabled);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			Enabled = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "channels.toggleSignatures";
		}
	}
}
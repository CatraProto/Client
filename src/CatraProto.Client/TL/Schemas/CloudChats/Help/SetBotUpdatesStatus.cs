using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SetBotUpdatesStatus : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -333262899; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("pending_updates_count")]
		public int PendingUpdatesCount { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PendingUpdatesCount);
			writer.Write(Message);

		}

		public void Deserialize(Reader reader)
		{
			PendingUpdatesCount = reader.Read<int>();
			Message = reader.Read<string>();
		}

		public override string ToString()
		{
			return "help.setBotUpdatesStatus";
		}
	}
}
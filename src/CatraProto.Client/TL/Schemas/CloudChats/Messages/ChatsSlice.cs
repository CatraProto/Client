using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatsSlice : ChatsBase
	{


        public static int StaticConstructorId { get => -1663561404; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("count")]
		public int Count { get; set; }

[JsonPropertyName("Chats_")]
		public override IList<ChatBase> Chats_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Chats_);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Chats_ = reader.ReadVector<ChatBase>();

		}
	}
}
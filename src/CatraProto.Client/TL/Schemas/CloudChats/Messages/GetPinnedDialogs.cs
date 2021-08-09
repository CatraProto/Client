using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPinnedDialogs : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -692498958; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(PeerDialogsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("folder_id")]
		public int FolderId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();

		}
	}
}
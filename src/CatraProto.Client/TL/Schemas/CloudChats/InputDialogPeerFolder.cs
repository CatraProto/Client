using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeerFolder : InputDialogPeerBase
	{


        public static int StaticConstructorId { get => 1684014375; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("folder_id")]
		public int FolderId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			FolderId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "inputDialogPeerFolder";
		}
	}
}
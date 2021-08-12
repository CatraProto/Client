using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FilePdf : FileTypeBase
	{


        public static int StaticConstructorId { get => -1373745011; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{
		}

		public override string ToString()
		{
			return "storage.filePdf";
		}
	}
}
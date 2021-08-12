using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
	public partial class FilePartial : FileTypeBase
	{


        public static int StaticConstructorId { get => 1086091090; }
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
			return "storage.filePartial";
		}
	}
}
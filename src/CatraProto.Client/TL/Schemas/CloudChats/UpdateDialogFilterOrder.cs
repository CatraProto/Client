using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDialogFilterOrder : UpdateBase
	{


        public static int StaticConstructorId { get => -1512627963; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("order")]
		public IList<int> Order { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Order);

		}

		public override void Deserialize(Reader reader)
		{
			Order = reader.ReadVector<int>();
		}

		public override string ToString()
		{
			return "updateDialogFilterOrder";
		}
	}
}
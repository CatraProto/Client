using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDcOptions : UpdateBase
	{


        public static int StaticConstructorId { get => -1906403213; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dc_options")]
		public IList<DcOptionBase> DcOptions { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcOptions);

		}

		public override void Deserialize(Reader reader)
		{
			DcOptions = reader.ReadVector<DcOptionBase>();
		}

		public override string ToString()
		{
			return "updateDcOptions";
		}
	}
}
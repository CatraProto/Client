using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShort : UpdatesBase
	{


        public static int StaticConstructorId { get => 2027216577; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("update")]
		public UpdateBase Update { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Update);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Update = reader.Read<UpdateBase>();
			Date = reader.Read<int>();

		}
	}
}
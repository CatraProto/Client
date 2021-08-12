using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PromoDataEmpty : PromoDataBase
	{


        public static int StaticConstructorId { get => -1728664459; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("expires")]
		public override int Expires { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
		}

		public override string ToString()
		{
			return "help.promoDataEmpty";
		}
	}
}
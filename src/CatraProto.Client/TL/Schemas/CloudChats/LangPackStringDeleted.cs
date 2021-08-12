using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackStringDeleted : LangPackStringBase
	{


        public static int StaticConstructorId { get => 695856818; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("key")]
		public override string Key { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();
		}

		public override string ToString()
		{
			return "langPackStringDeleted";
		}
	}
}
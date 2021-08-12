using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class JsonObjectValue : JSONObjectValueBase
	{


        public static int StaticConstructorId { get => -1059185703; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("key")]
		public override string Key { get; set; }

[JsonPropertyName("value")]
		public override JSONValueBase Value { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Value);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<string>();
			Value = reader.Read<JSONValueBase>();
		}

		public override string ToString()
		{
			return "jsonObjectValue";
		}
	}
}
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputClientProxy : InputClientProxyBase
	{


        public static int StaticConstructorId { get => 1968737087; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("address")]
		public override string Address { get; set; }

[JsonPropertyName("port")]
		public override int Port { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Address);
			writer.Write(Port);

		}

		public override void Deserialize(Reader reader)
		{
			Address = reader.Read<string>();
			Port = reader.Read<int>();

		}
	}
}
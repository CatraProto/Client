using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 648939889; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("new_value")]
		public bool NewValue { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			NewValue = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "channelAdminLogEventActionToggleSignatures";
		}
	}
}
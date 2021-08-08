using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 241923758; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_value")]
		public ChannelLocationBase PrevValue { get; set; }

[JsonPropertyName("new_value")]
		public ChannelLocationBase NewValue { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevValue);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<ChannelLocationBase>();
			NewValue = reader.Read<ChannelLocationBase>();

		}
	}
}
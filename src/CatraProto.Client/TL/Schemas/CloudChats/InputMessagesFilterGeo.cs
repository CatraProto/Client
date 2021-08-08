using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessagesFilterGeo : MessagesFilterBase
	{


        public static int StaticConstructorId { get => -419271411; }
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
	}
}
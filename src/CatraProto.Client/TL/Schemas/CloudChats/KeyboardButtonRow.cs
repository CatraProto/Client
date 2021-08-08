using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRow : KeyboardButtonRowBase
	{


        public static int StaticConstructorId { get => 2002815875; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("buttons")]
		public override IList<KeyboardButtonBase> Buttons { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Buttons);

		}

		public override void Deserialize(Reader reader)
		{
			Buttons = reader.ReadVector<KeyboardButtonBase>();

		}
	}
}
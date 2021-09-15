using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRow : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase
	{


        public static int StaticConstructorId { get => 2002815875; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("buttons")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase> Buttons { get; set; }

        
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
			Buttons = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase>();

		}
				
		public override string ToString()
		{
		    return "keyboardButtonRow";
		}
	}
}
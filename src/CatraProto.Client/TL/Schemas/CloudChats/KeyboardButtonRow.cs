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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2002815875; }
        
[Newtonsoft.Json.JsonProperty("buttons")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase> Buttons { get; set; }


        #nullable enable
 public KeyboardButtonRow (IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase> buttons)
{
 Buttons = buttons;
 
}
#nullable disable
        internal KeyboardButtonRow() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
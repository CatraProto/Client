using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonBuy : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1344716869; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public KeyboardButtonBuy (string text)
{
 Text = text;
 
}
#nullable disable
        internal KeyboardButtonBuy() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteString(Text);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trytext = reader.ReadString();
if(trytext.IsError){
return ReadResult<IObject>.Move(trytext);
}
Text = trytext.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "keyboardButtonBuy";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputKeyboardButtonUserProfile : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        public static int StaticConstructorId { get => -376962181; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


        #nullable enable
 public InputKeyboardButtonUserProfile (string text,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
{
 Text = text;
UserId = userId;
 
}
#nullable disable
        internal InputKeyboardButtonUserProfile() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
				
		public override string ToString()
		{
		    return "inputKeyboardButtonUserProfile";
		}
	}
}
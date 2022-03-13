using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class InviteText : CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase
	{


        public static int StaticConstructorId { get => 415997816; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public sealed override string Message { get; set; }


        #nullable enable
 public InviteText (string message)
{
 Message = message;
 
}
#nullable disable
        internal InviteText() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Message);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "help.inviteText";
		}
	}
}
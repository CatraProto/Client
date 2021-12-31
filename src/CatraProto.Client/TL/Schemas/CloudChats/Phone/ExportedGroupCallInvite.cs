using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class ExportedGroupCallInvite : CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInviteBase
	{


        public static int StaticConstructorId { get => 541839704; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("link")]
		public override string Link { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Link);

		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "phone.exportedGroupCallInvite";
		}
	}
}
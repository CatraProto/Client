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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 541839704; }
        
[Newtonsoft.Json.JsonProperty("link")]
		public sealed override string Link { get; set; }


        #nullable enable
 public ExportedGroupCallInvite (string link)
{
 Link = link;
 
}
#nullable disable
        internal ExportedGroupCallInvite() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
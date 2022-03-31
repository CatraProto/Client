using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSetNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -738646805; }
        

        
        public StickerSetNotModified() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "messages.stickerSetNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
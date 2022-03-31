using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSetInstallResultSuccess : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 946083368; }
        

        
        public StickerSetInstallResultSuccess() 
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
		    return "messages.stickerSetInstallResultSuccess";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
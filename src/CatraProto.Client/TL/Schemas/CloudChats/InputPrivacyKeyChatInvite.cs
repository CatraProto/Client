using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyKeyChatInvite : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1107622874; }
        

        
        public InputPrivacyKeyChatInvite() 
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
		    return "inputPrivacyKeyChatInvite";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
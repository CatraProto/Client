using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyKeyPhoneP2P : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -610373422; }
        

        
        public InputPrivacyKeyPhoneP2P() 
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
		    return "inputPrivacyKeyPhoneP2P";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
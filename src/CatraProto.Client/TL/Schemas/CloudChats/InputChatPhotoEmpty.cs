using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChatPhotoEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 480546647; }
        

        
        public InputChatPhotoEmpty() 
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
		    return "inputChatPhotoEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
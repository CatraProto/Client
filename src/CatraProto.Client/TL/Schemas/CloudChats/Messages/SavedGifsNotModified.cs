using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SavedGifsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -402498398; }
        

        
        public SavedGifsNotModified() 
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
		    return "messages.savedGifsNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
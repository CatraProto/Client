using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class TopPeersDisabled : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1255369827; }
        

        
        public TopPeersDisabled() 
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
		    return "contacts.topPeersDisabled";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}
using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class NotifyUsers : CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1261946036; }
        

        
        public NotifyUsers() 
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
		    return "notifyUsers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}